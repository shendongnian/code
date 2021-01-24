    using (DataTable dt = new DataTable())
    {
        Object check1 = dt.Compute("2 < 4", String.Empty);
        Console.WriteLine(check1.GetType().ToString()); // System.Boolean
        Console.WriteLine(check1.ToString()); // True    
            
        Object check2 = dt.Compute("2 > 4", String.Empty);
        Console.WriteLine(check2.GetType().ToString()); // System.Boolean
        Console.WriteLine(check2.ToString()); // False   
        Object check3 = dt.Compute("2 + 4", String.Empty);
        Console.WriteLine(check3.GetType().ToString()); // System.Int32
        Console.WriteLine(check3.ToString()); // 6
    }
