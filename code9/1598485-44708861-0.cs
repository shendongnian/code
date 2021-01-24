    using System.Data;
    
    //string mathExp = "3 * (2+4)"
    public string ShiestyEval(string mathExp)
    {
        DataTable dt = new DataTable();
        var v = dt.Compute(mathExp,"");
        return v;
    }
