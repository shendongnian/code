    void addTestData(Chart chart)
    {
        Random rnd = new Random(9);
        for (int i = 0; i < 100; i++)
        {
            double x = Math.Cos(i/10f )*88 + rnd.Next(5);
            double y = Math.Sin(i/11f)*88 + rnd.Next(5);
            double z = Math.Sqrt(i*2f)*88 + rnd.Next(5);
            AddXY3d( chart.Series[0], x, y, z);
            AddXY3d( chart.Series[1], x-111, y-222, z);
        }
    }
