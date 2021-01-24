    string s1 = "پایان خدمت", s2 = "پايان خدمت"; char c1 = 'ی', c2 = 'ي';
    var ci = System.Globalization.CultureInfo.InvariantCulture.CompareInfo;
    Debug.Print(ci.Compare(s1, s2, CompareOptions.IgnoreNonSpace) + ""); // 0
    Debug.Print(ci.Compare(s1, s2                               ) + ""); // 1
    Debug.Print(ci.IndexOf(s1, c1, CompareOptions.IgnoreNonSpace) + ""); // 2
    Debug.Print(ci.IndexOf(s1, c1                               ) + ""); // 2
    Debug.Print(ci.IndexOf(s1, c2, CompareOptions.IgnoreNonSpace) + ""); // 2
    Debug.Print(ci.IndexOf(s1, c2                               ) + ""); // -1
