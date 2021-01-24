    public class SampleViewModel
    {
        public PlotModel Model { get; set; }
    
        public SampleViewModel()
        {
            Model = GetModel();
        }
    
        private PlotModel GetModel()
        {
            var plotModel1 = new PlotModel();
            plotModel1.Title = "Sample Pie Chart";
            plotModel1.Background = OxyColors.LightGray;
    
            var pieSeries1 = new PieSeries();
            pieSeries1.StartAngle = 90;
            pieSeries1.FontSize = 18;
            pieSeries1.FontWeight = FontWeights.Bold;
            pieSeries1.TextColor = OxyColors.LightGray;
            pieSeries1.Slices.Add(new PieSlice("A", 12));
            pieSeries1.Slices.Add(new PieSlice("B", 14));
            pieSeries1.Slices.Add(new PieSlice("C", 16));
    
            plotModel1.Series.Add(pieSeries1);
    
            return plotModel1;
        }
    }
