    var lines = File.ReadAllLines("c:\\myfile.csv");
    //1. Read all headers
    string[] columnHeaders = lines[0].Split(';');
    //2. Instantiate your end result variable.
    List<Dictionary<string, string>> linesAsDictionaries = new List<Dictionary<string, string>>();
    //3. Process all lines (except the header row!)
    foreach(var line in lines.Skip(1))
    {
        //3.1 Instantiate the resulting dictionary
        var newDict = new Dictionary<string, string>();
        //3.2 Split the data
        var cells = line.Split(';');
        //3.3 Add an entry for each retrieved header.
        for (int i = 0; i < columnHeaders.Length; i++)
        {
            newDict.Add(columnHeaders[i], cells[i]);
        }
        //3.4 Add the dictionary to the resulting list
        linesAsDictionaries.Add(newDict);
    }
    return linesAsDictionaries;
