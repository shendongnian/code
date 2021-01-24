        private void ChartSample_Load(object sender, EventArgs e)
        {
            var listChartItems = new List<PointChart>();
            listChartItems.Add(new PointChart { SeryName = "Seri 1",XValue = 2,YValue = 3});
            listChartItems.Add(new PointChart { SeryName = "Seri 1",XValue = 3,YValue = 5});
            listChartItems.Add(new PointChart { SeryName = "Seri 1",XValue = 4,YValue = 7});
            listChartItems.Add(new PointChart { SeryName = "Seri 1",XValue = 5,YValue = 9});
            listChartItems.Add(new PointChart { SeryName = "Seri 2", XValue = 1, YValue = 10 });
            listChartItems.Add(new PointChart { SeryName = "Seri 2", XValue = 8, YValue = 11 });
            listChartItems.Add(new PointChart { SeryName = "Seri 2", XValue = 4, YValue = 5});
            listChartItems.Add(new PointChart { SeryName = "Seri 2", XValue = 6, YValue = 3 });
            BindDataToChart(listChartItems);
        }
