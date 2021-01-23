    public static double ApplyFilterOnOneCoord(double u, double v, double Du, double Dv, int CenterX, int CenterY, double Theta, int N)
    {
        double uStar = KassWitkinFunction.uStar(u, v, CenterX, CenterY, Theta);
        double vStar = KassWitkinFunction.vStar(u, v, CenterX, CenterY, Theta);
        double uStarDu = uStar / Du;
        double vStarDv = vStar / Dv;
        double sqrt = Math.Sqrt(uStarDu + vStarDv);
        double _2n = 2 * N;
        double pow = Math.Pow(sqrt, _2n);
        if (!double.IsNaN(sqrt) && Math.Abs(pow - Math.Pow(uStarDu + vStarDv, N)) > 1e-7)
        {
             //execution will never reach here!!
		}
        pow = Math.Pow(uStarDu + vStarDv, N);
        double div = 1 + 0.414 * pow;
        double returns = 1 / div;
        return returns;
    }
