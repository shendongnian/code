    string s = "17.4. XXX"; DateTime d;
    
    if (DateTime.TryParseExact(s.Split(' ')[0], "d.M.", 
        System.Globalization.CultureInfo.InvariantCulture, 
        System.Globalization.DateTimeStyles.None, out d)) 
    {
        // matches
        Debug.Print($"{d}"); // "4/17/2017 12:00:00 AM"
    }
