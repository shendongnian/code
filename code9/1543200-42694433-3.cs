    // check for the keys 
    if(
        ( // if numeric between 0 and 9
            e.Key >= Windows.System.VirtualKey.Number0 
            &&
            e.Key <= Windows.System.VirtualKey.Number9
        ) 
        || // or
        ( // numeric from numpad between 0 and 9
            e.Key >= Windows.System.VirtualKey.NumberPad0
            &&
            e.Key <= Windows.System.VirtualKey.NumberPad9 
        )
        || // or decimal mark
        e.Key == Windows.System.VirtualKey.Decimal
    )
    {
        // your logic
    }
    
