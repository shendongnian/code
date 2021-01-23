    protected decimal Calculate(string a, string b)
    {
        decimal ad = Convert.ToDecimal(a);
        decimal bd = Convert.ToDecimal(bd);
    
        if (bd == 0)
        {
            return 0; // or whatever
        }
    
        return ad / bd;
    }
