    public double Func( string a, double b, double c, double d, double e)
    { 
        // Use .equals to compare strings!
        if (a.Equals("c"))
        {
            // Are you sure this shouldn't be (b-c)/(d-e)?
            res= b-c/d-e;
        }
        else if (a.Equals("p"))
        {
            // Are you sure this shouldn't be (b+c)/(d+e)?
            res= b+c/d+e;
        }
        return res;
    }
