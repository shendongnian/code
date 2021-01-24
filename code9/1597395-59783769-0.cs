private string GetChartBase64Image(Chart chart)
{
    using (MemoryStream memStream = new MemoryStream())
    {
        chart.SaveImage(memStream, ChartImageFormat.Png);
        byte[] imageArray = memStream.ToArray();
        return Convert.ToBase64String(imageArray);
    }
}
In above the example, Class Chart and ChartImageFormat are defined in namespace `System.Web.UI.DataVisualization.Charting`
