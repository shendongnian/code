        if (session.FileExists(path))
        {
            Console.WriteLine("That path exists already.");
        }
        else
        {
            session.CreateDirectory(path);
            Console.WriteLine("The directory was created successfully");
        }
