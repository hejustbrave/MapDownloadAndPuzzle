using System.Diagnostics;
using System.Reflection;

namespace Tifer
{
    public class Crawler
    {
        private static readonly string pythonPath = "dll\\python311\\python.exe";
        private static readonly string ScriptPath = "dll\\python311\\get.py";

        public string token;
        public int zoom;
        public int minCol;
        public int maxCol;
        public int minRow;
        public int maxRow;
        public string outputFilePath;

        public string Run()
        {
            try
            {
                using (Process process = new Process())
                {
                    string FolderPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.RedirectStandardInput = false;
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.RedirectStandardError = true;
                    process.StartInfo.CreateNoWindow = true;

                    process.StartInfo.FileName = FolderPath+"\\"+pythonPath;

                    //token zoom mincol maxcol minrow maxrow outputfielpath
                    string arguments = $"{FolderPath}\\{ScriptPath} {token} {zoom} {minRow} {maxRow} {minCol} {maxCol} {outputFilePath}";
                    process.StartInfo.Arguments = arguments;

                    process.Start();
                    process.BeginOutputReadLine();
                    process.WaitForExit();
                }

                return string.Empty;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
