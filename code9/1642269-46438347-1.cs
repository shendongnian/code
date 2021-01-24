    private void CoreWetStrokeUpdateSource_WetStrokeContinuing(CoreWetStrokeUpdateSource sender, CoreWetStrokeUpdateEventArgs args)
    {
        var points = args.NewInkPoints;
        foreach (var point in points)
        {
            Debug.WriteLine($"-----{ point.Position.X}--- {point.Position.Y}--");
        }
    }
