            foreach (var n in classChartData.Slice)
            {
                areaChart.Series.Add(new PieSeries
                {
                    Title = n.Key,
                    Values = new ChartValues<double> { n.Value }
                });
            }
            areaChart.LegendLocation = LegendLocation.Bottom;
classChartData
        private Dictionary<string, double> slice;
        public Dictionary<string, double> Slice
        {
            get { return slice; }
            set { slice = value; }
        }
        public void AddSlice(string slicename, double slicevalue)
        {
            slice.Add(slicename, slicevalue);
        }
