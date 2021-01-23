        string line = null;
        while(line = sr.ReadLine() != null)
            sw.WriteLine(line.Replace("’", "").Replace("'", ""));
    } 
    System.IO.File.Delete(file);
    System.IO.File.Move(tmp,  file);
