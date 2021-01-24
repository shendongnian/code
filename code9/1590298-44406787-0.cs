    var lineFields = File.ReadLines("TransDetail.txt")
        .Select(line => line.Split(new string[] { "#" }, StringSplitOptions.None))
        .Where(arr => arr.Length >= 5)
        .ToArray();
    if(lineFields.Length > 0)
    {
        string[] lastFields = lineFields.Last();
        int helmetInt;
        bool valid = int.TryParse(lastFields[2].Substring(1), out helmetInt);
        // check if it's valid otherwise log/throw error
        // you dont need the if...else if...else if... part, this is enough: 
        string helmetCode = "H" + helmetInt.ToString("D3");
        // ...
    }
