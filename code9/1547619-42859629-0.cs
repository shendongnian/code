    string filename = ....
    if (!Path.HasExtension(filename))
    {
        string t = Path.ChangeExtension(filename, ".vbe");
        File.Move(filename, t);
        filename = t;
    }
    // rest of your code
        
