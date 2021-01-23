    public static double PrazenWindowDensity(double[][] Xn, double x, double sigma2)
    {
        double gauss=0;
        int count=0;
        for (int i=0; i<Xn.Length; i++)
        {
            gauss+=Xn[i].Sum((item) => GausianFunction(item, x, sigma2));
            count+=Xn[i].Length;
        }
        return gauss/count;
    }
