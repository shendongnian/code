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
                    // ***** updated to use .NET MidpointRounding.AwayFromZero rounding ***** //
                    retval = Math.Round(n, p, MidpointRounding.AwayFromZero);
                }
                else
                {
                    retval = (double)(Math.Round((decimal)(n) / temp) * temp);
                }
            }
            return retval;
        }
