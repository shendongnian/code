    Dictionary<string, string> found = new Dictionary<string, string>();
    string line;
    foreach (string filename in Directory.GetFiles("path-to-directory"))
    {
        using (StreamReader file = new StreamReader(filename))
        {
            while ((line = file.ReadLine()) != null)
            {
                if (line.Contains("Error: 1"))
                {
                    found.Add(line,filename);
                    MessageBox.Show("Error Found");
                }
            }   
        }  
    }
