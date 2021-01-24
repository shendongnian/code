    public static class StatsHelper
    {
        public static LagCorr CrossCorrelation(double[] x1, double[] x2)
        {
            if (x1.Length != x2.Length)
                throw new Exception("Samples must have same size.");
    
            var len = x1.Length;
            var len2 = 2 * len;
            var len3 = 3 * len;
            var s1 = new double[len3];
            var s2 = new double[len3];
            var cor = new double[len2];
            var lag = new double[len2];
    
            Array.Copy(x1, 0, s1, len, len);
            Array.Copy(x2, 0, s2, 0, len);
    
            for (int i = 0; i < len2; i++)
            {
                cor[i] = Correlation.Pearson(s1, s2);
                lag[i] = i - len;
                Array.Copy(s2,0,s2,1,s2.Length-1);
                s2[0] = 0;
            }
    
            return new LagCorr { Corr = cor, Lag = lag };
        }
    }
