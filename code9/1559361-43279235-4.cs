    using (StreamWriter writer = File.AppendText(dir + newfilename))
    {
        int id = 0;
 
        foreach(var line in File.ReadLines(f))
        {
            if (line.Substring(0,2) == "01")
               id++;
            writer.WriteLine($"{line}*{id}");
        }
    }
