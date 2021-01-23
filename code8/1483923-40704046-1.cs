    public static readonly double Epsilon = 2.2204460492503131E-16;
    public static bool AreClose(Thickness value1, Thickness value2)
    {
        return AreClose(value1.Left, value2.Left) && AreClose(value1.Top, value2.Top) && AreClose(value1.Right, value2.Right) && AreClose(value1.Bottom, value2.Bottom);
    }
    public static bool AreClose(double value1, double value2)
    {
        if (Math.Abs(value1 - value2) < 0.00005)
        {
            return true;
        }
        var a = (Math.Abs(value1) + Math.Abs(value2) + 10.0) * Epsilon;
        var b = value1 - value2;
        return (-a < b) && (a > b);
    }
