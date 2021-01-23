        static double rthRoot(double r, double x) //1
        {
            //original
            double y = double.NaN;
            if (x > 0)
            {
                y = Math.Exp((Math.Log(x)) / r);
            }
            if (r % 2 != 0)
            {
                if (x < 0)
                {
                    y = -(Math.Exp((Math.Log(Math.Abs(x))) / r));
                }
            }
            return y;
        }
        static double rthRoot(double r, int[] x) //2
        {
            //overload
            double y = double.NaN;
            //whatever
            return y;
        }
