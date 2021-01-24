    private void AddHeader(string filename)
    {
        string tempFilename = "temp.csv";
        bool toCopy = false;
        
        using (var sw = new StreamWriter(tempFilename, false))
        {
            //check if header exists
            using(var sr = new StreamReader(filename))
            {
                var line = sr.ReadLine(); // first line
                if(line != null && line != "Your Header") // check header exists
                {
                    toCopy = true; // need copy temp file to your original csv
                    // write your header into the temp file
                    sw.WriteLine("Your Header");
                    
                    while(line != null)
                    {
                        sw.WriterLine(line);
                        line = sr.ReadLine();
                    }
                }
            }
        }
        
        if(toCopy)
            File.Copy(tempFilename, filename, true);
        File.Delete(tempFilename);
    }
