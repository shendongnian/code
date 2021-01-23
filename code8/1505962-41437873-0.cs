    var wind_chill = WindChillDbl(20.0, 7.0);
    Console.WriteLine(String.Format("{0:R}", wind_chill));
    public static double WindChillDbl(double temp, double wind_speed)
    {
        return 35.74 + 0.6215 * temp + (0.4275 * temp - 35.75) * System.Math.Pow(wind_speed, 0.16);
    }
