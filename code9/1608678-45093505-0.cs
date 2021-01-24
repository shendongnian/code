    bool myBool = false;
    using (StreamReader file = new StreamReader(path, true))
    {
        var line = file.ReadLine();
        var pieces = line.Split(',');
        if (pieces.Length > 0 && (pieces[0] == "Apple") || pieces[0] == "Orange"))
        {
            isValid = true;
        }
    }
    return myBool;
