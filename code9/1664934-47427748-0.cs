    if (name.IndexOfAny(System.IO.Path.GetInvalidFileNameChars()) == -1)
    {
        var db = new testEntities();
        var fileToUpload = new testFile();
        // **this is where I'm using my chars** 
        fileToUpload.name = Path.GetFileNameWithoutExtension(name);
        fileToUpload.extension = Path.GetExtension(name);
        fileToUpload.data = data;
        db.test.Add(fileToUpload);
        db.SaveChanges();
    }
    else
    {
        Console.WriteLine("Filename has invalid characters");
    }
