    using LiveCharts.Defaults;
    ChartValues<ObservablePoint> List1Points = new ChartValues<ObservablePoint>();
    For(int i = x1List, i < x1List.Count, i++)
    {
        List1Points.Add(new ObservablePoint 
        { 
            X=x1List[i], 
            Y=y1List[i]
        });
    }
