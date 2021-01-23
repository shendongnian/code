    public static int CustomRound(double value)
    {
        int sign = Math.Sign(value);
        double absValue = Math.Abs(value);
        int absResult =  (int)Math.Round(absValue - 0.01, 0, MidpointRounding.AwayFromZero);
        return absResult * sign;
    }
