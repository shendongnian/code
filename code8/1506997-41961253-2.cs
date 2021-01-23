        public static double Round(double n, int p)
        {
            double retval;
            if (double.IsNaN(n) || double.IsInfinity(n))
            {
                retval = double.NaN;
            }
            else if (double.MaxValue == n)
                return double.MaxValue;
            else if (double.MinValue == n)
                return 0;
            else
            {
                if (p >= 0)
                {
                    int temp = (int)Math.Pow(10, p);
                    double delta = 0.5;
                    int x = p + 1;
                    while (x > 0)
                    {
                        delta = delta / 10;
                        x--;
                    }
                    retval = (double)Math.Round((decimal)n, p, MidpointRounding.AwayFromZero);
                }
                else
                {
                    int temp = (int)Math.Pow(10, Math.Abs(p));
                    retval = (double)(Math.Round((decimal)(n) / temp) * temp);
                }
            }
            return retval;
        }
