    string oldFile = @"textfile1.txt";
    string newFile = @"textfile2.txt";
    string test = @"testfile.txt";
    
    string[] lines = File.ReadAllLines(oldFile);
    
    using (StreamWriter w = File.AppendText(newFile))
    {
        foreach(var line in lines) {
            if (!line.Contains(textbox1.Text))
            {
                w.WriteLine(line);
            }
        }
    }
