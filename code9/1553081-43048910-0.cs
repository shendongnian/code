    string[] lines = System.IO.File.ReadAllLines(file);
    bool first = true;
    foreach (string line in lines)
    {
        if(!first)
        {
           ...
        }
        first = false;
    }
