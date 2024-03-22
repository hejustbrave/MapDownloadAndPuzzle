using GMap.NET;
using OSGeo.GDAL;
using OSGeo.OSR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Tifer
{
    public class Combiner
    {

        /// <summary>
        /// 拼接瓦片
        /// </summary>
        /// <param name="tilesBounds"></param>
        /// <param name="tilePath"></param>
        /// <param name="outPutFileName"></param>
        public void CombineTiles(Tile tilesBounds, string tilePath, string outPutFileName,PointLatLng minLngLat, PointLatLng maxLngLat)
        {
            if (File.Exists(outPutFileName))
            {
                File.Delete(outPutFileName);
            }
            int imageWidth = 256 * (tilesBounds.maxCol - tilesBounds.minCol + 1);
            int imageHeight = 256 * (tilesBounds.maxRow - tilesBounds.minRow + 1);

            Driver driver = Gdal.GetDriverByName("GTiff");
            Dataset destDataset = driver.Create(outPutFileName, imageWidth, imageHeight, 3, OSGeo.GDAL.DataType.GDT_Byte, null);

            // 设置影像的四个角的地理坐标
            double[] adfGeoTransform = new double[6]
            {
                minLngLat.Lng, // 左上角 x经
                (maxLngLat.Lng-minLngLat.Lng)/imageWidth, // X方向单位像素偏移量
                0, // 旋转角度
                minLngLat.Lat, // 左上角 y纬
                0, // 垂直像元大小
                (maxLngLat.Lat-minLngLat.Lat)/imageHeight // Y方向单位像素偏移量
            };

            // 设置地理坐标转换参数
            destDataset.SetGeoTransform(adfGeoTransform);

            SpatialReference srs = new SpatialReference("");
            srs.ImportFromEPSG(4326);
            srs.ExportToWkt(out string srsWkt, null);
            destDataset.SetProjection(srsWkt);

            for (int row = tilesBounds.minRow; row <= tilesBounds.maxRow; row++)
            {
                for (int col = tilesBounds.minCol; col <= tilesBounds.maxCol; col++)
                {
                    int wmtsRow = (int)Math.Pow(2, (double)tilesBounds.zoomLevel) - row - 1;
                    try
                    {
                        string sourceFileName = @$"{tilePath}\{tilesBounds.zoomLevel}\{row}\{col}.png";
                        if (File.Exists(sourceFileName))
                        {
                            Dataset sourceDataset = Gdal.Open(sourceFileName, Access.GA_ReadOnly);
                            if (sourceDataset != null)
                            {
                                SaveBitmapBuffered(sourceDataset, destDataset, col - tilesBounds.minCol, row - tilesBounds.minRow);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            destDataset.Dispose();
        }

        private void SaveBitmapBuffered(Dataset src, Dataset dst, int x, int y)
        {
            if (src.RasterCount < 3)
            {
                System.Environment.Exit(-1);
            }

            // Get the GDAL Band objects from the Dataset
            Band redBand = src.GetRasterBand(1);
            Band greenBand = src.GetRasterBand(2);
            Band blueBand = src.GetRasterBand(3);

            // Get the width and height of the raster
            int width = redBand.XSize;
            int height = redBand.YSize;

            byte[] r = new byte[width * height];
            byte[] g = new byte[width * height];
            byte[] b = new byte[width * height];

            redBand.ReadRaster(0, 0, width, height, r, width, height, 0, 0);
            greenBand.ReadRaster(0, 0, width, height, g, width, height, 0, 0);
            blueBand.ReadRaster(0, 0, width, height, b, width, height, 0, 0);

            Band wrb = dst.GetRasterBand(1);
            wrb.WriteRaster(x * width, y * height, width, height, r, width, height, 0, 0);
            Band wgb = dst.GetRasterBand(2);
            wgb.WriteRaster(x * width, y * height, width, height, g, width, height, 0, 0);
            Band wbb = dst.GetRasterBand(3);
            wbb.WriteRaster(x * width, y * height, width, height, b, width, height, 0, 0);
        }

    }

    public class Tile
    {
        public int minCol;
        public int maxCol;
        public int minRow;
        public int maxRow;
        public int zoomLevel;
    }
}
