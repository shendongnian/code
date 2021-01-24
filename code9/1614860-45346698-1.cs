    string recordId = lines[i].Substring(0, 2);
    switch (recordId)
    {
        case "00":
            return Parse00(lines[i]); //public static List<mainInfo> Parse00(string line);
        case "11":
            return Parse11(lines[i]); //public static List<param> Parse11(string line);
