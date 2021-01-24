    try
    {
        System.Data.DataTable dt = new System.Data.DataTable();
        var result = dt.Compute("(10 / 0) + (29 / 0.0) + (10 / 0.1)", "");
        //Work with further result here
    }
    catch(System.DivideByZeroException e)
    {
        //Your exception here    
    }
