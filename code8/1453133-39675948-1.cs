    using System.Collections.Generic;
    delegate bool delType(string str);
    Dictionary<string, delType> pairs = new Dictionary<string, delType> {
        { "hostStarts", hostname.StartStartsith },
        { "hostContains" hostname.Contains },
        ...
        { "pathStarts", pathname.StartStartsith },
        ...
    };
    foreach (XElement xe in Tests)
    {
        foreach (KeyValuePair<string, delType> pair in pairs)
        {
            string str = (string)xe.Element(pair.Key);
            if (!String.IsNullOrEmpty(str) && !pair.Value(str))
                continue;
        }
    }
