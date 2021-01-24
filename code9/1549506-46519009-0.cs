    var german = new System.Globalization.CultureInfo("de-DE");
    var english = new System.Globalization.CultureInfo("en-AU");
    // result "Guten tag"
    var greeting1 = Shared.Resources.Lang.ResourceManager.GetString("GREETING", german); 
    // result "Gidday mate"
    var greeting2 = Shared.Resources.Lang.ResourceManager.GetString("GREETING", english);
