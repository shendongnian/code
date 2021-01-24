    using OxyPlot.Annotations;
    double X = 0.0D;
    double Y = 0.87825D;
    LineAnnotation Line = new LineAnnotation()
    {
        StrokeThickness = 1,
        Color = OxyColors.Green,
        Type = LineAnnotationType.Horizontal,
        Text = (Y).ToString(),
        TextColor = OxyColors.White,
        X = X,
        Y = Y
        };
    myPlotViewModel.Annotations.Add(Line);
