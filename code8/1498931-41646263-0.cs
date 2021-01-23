    public class ThresholdColumnChart : Chart
    {
        private double _threshold = 50d;
        public double Threshold
        {
            get { return _threshold; }
            set { _threshold = value; Invalidate(); }
        }
        public ThresholdColumnChart() : base() { }
        protected override void OnCustomize()
        {
            base.OnCustomize();
            if (Series.Count != 1)
                return;
            Series.Add(new Series());
            foreach (var dataPoint in Series[0].Points)
            {
                var newDataPoint = new DataPoint();
                newDataPoint.XValue = dataPoint.XValue;
                newDataPoint.YValues[0] = (dataPoint.YValues[0] > _threshold ? 
                     dataPoint.YValues[0] - _threshold : 0);
                Series[1].Points.Add(newDataPoint);
                if (dataPoint.YValues[0] > _threshold)
                    dataPoint.YValues[0] = _threshold;
            }
            Series[0].ChartType = SeriesChartType.StackedColumn;
            Series[1].ChartType = SeriesChartType.StackedColumn;
            Series[1].Color = Color.Red;
        }
        
        protected override void OnPostPaint(ChartPaintEventArgs e)
        {
            base.OnPostPaint(e);
            if (!(e.ChartElement is ThresholdBarChart))
                return;
            if (Series.Count != 2)
                return;
            for (int i = 0; i < Series[0].Points.Count; i++)
                Series[0].Points[i].YValues[0] += Series[1].Points[i].YValues[0];
            Series.Remove(Series[1]);
        }
    }
