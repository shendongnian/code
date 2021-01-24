     public Brush DangerBrushFill { get; set; } = new SolidColorBrush(Colors.DarkOrange);
     public Brush DangerBrushStroke { get; set; } = new SolidColorBrush(Colors.Black);
     public CartesianMapper<Double> Mapper { get; set; }
     public ChartValues<double> ChartValues { get; private set; }
            Mapper = Mappers.Xy<Double>()
                .X((item, index) => item)
                .Y((item, index) => index)                
                .Fill((item, index) => 
                (item > 0 && index == DateTime.Now.Hour - 1) ? DangerBrushFill : null)
                .Stroke((item, index) =>
                (item > 0 && index == DateTime.Now.Hour - 1) ? DangerBrushFill : null);
            SeriesCollection = new SeriesCollection
            {
                new RowSeries
                {
                    Configuration=Mapper,
                    Values = ChartValues,
                    StrokeThickness = 3
                }
            };          
