    string tooldata = data.Substring(data.IndexOf(":=") + 2) ;
            
    string[] tooldataArray = tooldata.Split(new char[] { '[' }, StringSplitOptions.RemoveEmptyEntries);
    double[] xyzValue  = tooldataArray[1].Replace(']' ,' ')
                        .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(s => double.Parse(s, CultureInfo.InvariantCulture))
                        .ToArray();
    double[] Q1234value = tooldataArray[2].Replace(']', ' ')
                        .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(s => double.Parse(s, CultureInfo.InvariantCulture))
                        .ToArray();
