    /// <summary>
    /// Chart data
    /// </summary>
    public class PointChart
    {
        public string SeryName { get; set; }
        public int XValue { get; set; }
        public int YValue { get; set; }
    }
    /// <summary>
    /// Create series and points
    /// </summary>
    /// <param name="listChartItems"></param>
    private void BindDataToChart(List<PointChart> listChartItems)
        {
            if (listChartItems == null || listChartItems.Count == 0) return;
            chart1.Series.Clear();
            
            var listSeries = listChartItems.Select(x => new { x.SeryName }).Distinct().ToList();
            // Add list series
            foreach (var sery in listSeries)
            {
                var newSery = new Series(sery.SeryName);
                var listPoints = listChartItems.Where(x => x.SeryName == sery.SeryName).ToList();
                
                // Add sery's points
                foreach (var point in listPoints)
                {
                    newSery.Points.Add(new DataPoint(point.XValue, point.YValue));
                }
                chart1.Series.Add(newSery);
            }
        }
