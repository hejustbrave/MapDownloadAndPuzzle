using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET;
using GMap.NET.WindowsForms.Markers;

namespace Tifer
{
    public partial class Form1 : Form
    {
        GMapControl map;

        GMapOverlay overlay;

        List<PointLatLng> points;

        bool isDraw = false;

        GPoint minTile = GPoint.Empty;
        GPoint maxTile = GPoint.Empty;

        public Form1()
        {
            InitializeComponent();

            overlay = new GMapOverlay();
            points = new List<PointLatLng>();

            LoadGMap();

            GdalConfiguration.ConfigureGdal();
            GdalConfiguration.ConfigureOgr();
        }

        private void LoadGMap()
        {
            map = new GMapControl
            {
                Location = new Point(pn.Location.X, pn.Location.Y),
                Size = new Size(pn.Size.Width, pn.Size.Height),
                Padding = pn.Padding,
                Anchor = pn.Anchor,
                Visible = true,
                Zoom = 8,
                Position = new PointLatLng(23.32, 113.55)
            };
            pn.Controls.Add(map);

            if (!GMapControl.IsDesignerHosted)
            {
                GMapProvider.Language = LanguageType.ChineseSimplified;
                map.DragButton = MouseButtons.Left;
                map.EmptyMapBackground = System.Drawing.Color.FromArgb(240, 240, 240);
                map.EmptyTileBorders = new Pen(System.Drawing.Color.FromArgb(0, 100, 240), 3);
                map.EmptyTileColor = System.Drawing.Color.FromArgb(240, 240, 240);
                map.EmptyTileText = null;
                map.SelectedAreaFillColor = System.Drawing.Color.FromArgb(240, 240, 240);
                map.ShowCenter = false;
                map.MaxZoom = 20;
                map.MinZoom = 0;
                map.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left;
                map.MouseWheelZoomType = MouseWheelZoomType.MousePositionWithoutCenter;
                map.HelperLineOption = HelperLineOptions.ShowAlways;//辅助光标十字
                map.Manager.Mode = AccessMode.ServerOnly;//底图加载模式

                map.MapProvider = GMapProviders.TIANDITUMap;//高德地图
                var mapp = (TIANDITUMapProvider)map.MapProvider;

                map.Overlays.Add(overlay);

                map.OnMapClick += Map_OnMapClick;
                map.MouseMove += Map_MouseMove;
                map.OnMapZoomChanged += Map_OnMapZoomChanged;
            }
        }

        private void Map_OnMapZoomChanged()
        {
            tbZoom.Text = map.Zoom.ToString();
            nudZoom.Value = (decimal)map.Zoom;
        }

        private void Map_MouseMove(object? sender, MouseEventArgs e)
        {
            var p = map.FromLocalToLatLng(e.X, e.Y);

            tbLng.Text = p.Lng.ToString();
            tbLat.Text = p.Lat.ToString();

            if (!isDraw || points.Count != 1) { return; }

            overlay.Clear();
            GMapPolygon extent = CreateExtent(points[0], p);
            overlay.Polygons.Add(extent);
        }

        private void Map_OnMapClick(PointLatLng pointClick, MouseEventArgs e)
        {
            if (!isDraw) { return; }

            if (points.Count == 0)
            {
                overlay.Markers.Add(new GMarkerGoogle(pointClick, GMarkerGoogleType.blue));

                points.Add(pointClick);
            }
            else if (points.Count == 1)
            {
                overlay.Clear();

                GMapPolygon extent = CreateExtent(points[0], pointClick);

                overlay.Polygons.Add(extent);

                isDraw = false;

                string lngExtent = $"经度:{extent.Points[0].Lng}-{extent.Points[2].Lng}";
                string latExtent = $"纬度:{extent.Points[0].Lat}-{extent.Points[2].Lat}";
                tbExtent.Text = lngExtent + "\n" + latExtent;

                UpdateTileExtent();
            }
        }

        private GMapPolygon CreateExtent(PointLatLng p1, PointLatLng p2)
        {
            List<PointLatLng> p = new List<PointLatLng>();

            double minLat = Math.Min(p1.Lat, p2.Lat);
            double minLng = Math.Min(p1.Lng, p2.Lng);
            double maxLat = Math.Max(p1.Lat, p2.Lat);
            double maxLng = Math.Max(p1.Lng, p2.Lng);

            p.Add(new PointLatLng(minLat, minLng));
            p.Add(new PointLatLng(maxLat, minLng));
            p.Add(new PointLatLng(maxLat, maxLng));
            p.Add(new PointLatLng(minLat, maxLng));

            return new GMapPolygon(p, p.Count.ToString());
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            overlay.Clear();
            points.Clear();
            isDraw = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            overlay.Clear();
            points.Clear();
        }

        private void btnOutput_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog()
            {

            };

            if (dialog.ShowDialog() != DialogResult.OK) { return; }

            tbCrawlOutput.Text = dialog.SelectedPath;
            tbCombineOutput.Text = dialog.SelectedPath;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (map.MapProvider == null || map.MapProvider is not TIANDITUMapProvider tdtMap) { return; }

            tdtMap.token = tbToken.Text;

            map.ReloadMap();
        }

        private void nudZoom_ValueChanged(object sender, EventArgs e)
        {
            UpdateTileExtent();
        }

        private void UpdateTileExtent()
        {
            if (nudZoom.Value > 20 || nudZoom.Value < 1) { return; }

            if (overlay.Polygons.Count != 1) { return; }

            var minPixel = map.MapProvider.Projection.FromLatLngToPixel(overlay.Polygons[0].Points[1].Lat, overlay.Polygons[0].Points[1].Lng, (int)nudZoom.Value);
            minTile = map.MapProvider.Projection.FromPixelToTileXY(minPixel);
            var maxPixel = map.MapProvider.Projection.FromLatLngToPixel(overlay.Polygons[0].Points[3].Lat, overlay.Polygons[0].Points[3].Lng, (int)nudZoom.Value);
            maxTile = map.MapProvider.Projection.FromPixelToTileXY(maxPixel);

            tbTileExtent.Text = $"列:{minTile.X} - {maxTile.X}\n行:{minTile.Y} - {maxTile.Y}";
        }

        private void chkGrid_CheckedChanged(object sender, EventArgs e)
        {
            map.ShowTileGridLines = chkGrid.Checked;
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            lbCrawl.Text = "爬取中..";

            Crawler crawler = new Crawler()
            {
                token = tbToken.Text,
                zoom = (int)nudZoom.Value,
                minCol = (int)minTile.X,
                maxCol = (int)maxTile.X,
                minRow = (int)minTile.Y,
                maxRow = (int)maxTile.Y,
                outputFilePath = tbCrawlOutput.Text
            };

            string result = crawler.Run();

            if (result.Length != 0) { MessageBox.Show(result); }

            lbCrawl.Text = "爬取成功";
        }

        private void btnCombine_Click(object sender, EventArgs e)
        {
            lbCombine.Text = "拼接中";

            Tile tilesBounds = new Tile
            {
                minCol = (int)minTile.X,
                maxCol = (int)maxTile.X,
                minRow = (int)minTile.Y,
                maxRow = (int)maxTile.Y,
                zoomLevel = (int)nudZoom.Value
            };

            string outPutFileName = @$"{tbCombineOutput.Text}\combined.tif";


            var minTilePixel = map.MapProvider.Projection.FromTileXYToPixel(minTile);
            var minTileLatLng = map.MapProvider.Projection.FromPixelToLatLng(minTilePixel.X, minTilePixel.Y, tilesBounds.zoomLevel);
            var maxTilePixel = map.MapProvider.Projection.FromTileXYToPixel(new GPoint(maxTile.X + 1, maxTile.Y + 1));
            var maxTileLatLng = map.MapProvider.Projection.FromPixelToLatLng(maxTilePixel.X, maxTilePixel.Y, tilesBounds.zoomLevel);

            Combiner combiner = new Combiner();
            combiner.CombineTiles(tilesBounds, tbCombineOutput.Text, outPutFileName, minTileLatLng, maxTileLatLng);

            lbCombine.Text = "拼接成功";
        }

        private void btnCombineOutput_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() != DialogResult.OK) { return; }

            tbCombineOutput.Text = dialog.SelectedPath;
        }


        //测试异步返回执行进度，没试成功..懂的大哥可以说下怎么异步从python拿print的值后给控件赋值
        //public string Runn(Crawler c)
        //{
        //    try
        //    {
        //        string pythonPath = "dll\\python311\\python.exe";
        //        string ScriptPath = "dll\\python311\\get.py";

        //        using (process = new Process())
        //        {
        //            string FolderPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        //            process.StartInfo.UseShellExecute = false;
        //            process.StartInfo.RedirectStandardInput = false;
        //            process.StartInfo.RedirectStandardOutput = true;
        //            process.StartInfo.RedirectStandardError = true;
        //            process.StartInfo.CreateNoWindow = false;

        //            process.StartInfo.FileName = FolderPath + "\\" + pythonPath;

        //            string arguments = $"{FolderPath}\\{ScriptPath} {c.token} {c.zoom} {c.minRow} {c.maxRow} {c.minCol} {c.maxCol} {c.outputFilePath}";
        //            process.StartInfo.Arguments = arguments;

        //            //var asd = new Action((e) => { lbCrawl.Text = e.Data});
        //            process.OutputDataReceived += new DataReceivedEventHandler((sender, e) =>
        //            {
        //                Console.WriteLine(e.Data);
        //            });

        //            //token zoom mincol maxcol minrow maxrow outputfielpath

        //            process.Start();
        //            process.BeginOutputReadLine();

        //            process.WaitForExit();

        //            return "";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.Message;
        //    }
        //}
    }
}
