    double PrincipalPayment(int lRate, int i, int lTerm, double lStartLoanBalance)
    {
        var rppmt = Microsoft.VisualBasic.Financial.PPmt(lRate / 1200, i, lTerm, lStartLoanBalance);
        var rfnum = Microsoft.VisualBasic.Strings.FormatNumber(-rppmt, 3);
        return System.Math.Ceiling(Double.Parse(rfnum) * 100.0) / 100.0;
    }
