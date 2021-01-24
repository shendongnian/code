    void MoveAllBk(string from_path)
    {
        string to_path = @"D:\" + Today.ToString("dd-MM-yyyy");
        Directory.CreateDirectory(to_path);
        foreach (string file in Directory.GetFiles(from_path, "*.bk", SearchOption.AllDirectories))
        {
            string new_file = System.IO.Path.Combine(to_path, new System.IO.FileInfo(file).Name);
            if (System.IO.File.Exists(new_file)) { System.IO.File.Delete(new_file); }
            System.IO.File.Move(file, new_file);
        }
    }
