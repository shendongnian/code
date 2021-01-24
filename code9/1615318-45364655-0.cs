    int RGBdiff(Color c1, Color c2)
    {
        return Math.Abs(c1.R - c2.R) + Math.Abs(c1.G - c2.G) + Math.Abs(c1.B - c2.B);
    }
    Color ClosestColor(Color target, IEnumerable<Color> colors)
    {
        return colors.Min(c => Tuple.Create(RGBdiff(c, targert), c)).Item2;
    }
