    class ProcessFiles
    {
        string output = "path to .txt file"
        string filename = "path to .h C++ file"
    
        public void Remove_Comments()
        { 
            string[] lines = File.ReadAllLines(filename);
    
            using (StreamWriter writer = new StreamWriter(output))
            {
                foreach (string line in lines)
                {
                    if (!line.Contains("//".ToString()))
                    {
                        writer.WriteLine(line.Replace("public :", ""));
                    }
                 }
            }
        }
    }
