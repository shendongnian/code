    ChangeableEnum<Color> test = new ChangeableEnum<Color>();
    // get
    System.Diagnostics.Trace.WriteLine(test[Color.Red]);
            
    // set
    test[Color.Red] = 5436;
    // get again
    System.Diagnostics.Trace.WriteLine(test[Color.Red]);
