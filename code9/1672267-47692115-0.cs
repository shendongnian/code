    // default value for "ice"
    const string default_ice = "10";
    // default value for "sweet"
    const string default_sweet = "20";
    public void AddSomething(string ice = default_ice, string sweet = default_sweet)
    {
    
        // check if "ice" value is set
        if(string.IsNullOrEmpty(ice))
            ice = default_ice;    // set "ice" value to the default one
     
        // check if "sweet" value is set
        if(string.IsNullOrEmpty(sweet))
            sweet = default_sweet;  // set "sweet" value to the default one
    
        Console.Write(ice);
        Console.Write(sweet);
    }
