    private IEnumerable<double> GetDashArray(double length)
    {
        double useableLength = length - StrokeDashLine;
        int lines = (int)Math.Round(useableLength/(StrokeDashLine + StrokeDashSpace));
        useableLength -= lines*StrokeDashLine;
        double actualSpacing = useableLength/lines;
        yield return StrokeDashLine / StrokeThickness;
        yield return actualSpacing / StrokeThickness;
    } 
