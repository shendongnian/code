    string name = System.IO.Path.GetFileName(path);
    int output;
    bool isNumeric = int.TryParse(name[0].ToString(), out output);
    if(isNumeric)
    Console.WriteLine(System.IO.Path.GetFileName(path));
