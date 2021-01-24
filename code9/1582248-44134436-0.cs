    using System.IO;
    private static bool SaveExcelChartAsPNG(ChartObject co, 
        string path, string filename)
    {
        try
        {
            string filenamePNG = Path.ChangeExtension(filename, "png");
            string fullFilenamePNG = Path.Combine(path, filenamePNG);
            co.Select();
            co.Chart.Export(fullFilenamePNG, "PNG", false);
        }
        catch
        {
            // Save was not successful
            return false;
        }
        return true;
    }
