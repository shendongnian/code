    if(new String[] { ".png", ".jpeg" }.Contains(Path.GetExtension(fileupload1.FileName).ToLower()))
    {
        Console.WriteLine("found");
    }
    else
    {
        Console.WriteLine("not found");
    }
