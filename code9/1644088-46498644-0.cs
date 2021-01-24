    static async private Task<string> FileProcessor(string fn, IProgress<int> progress)
    {
        FileInfo fi = new FileInfo(fn);
        string newFN = "C:\temp\text.txt";
    
        int i = 0;
    
        using (StreamWriter sw = new StreamWriter(newFN))
        using (StreamReader sr = new StreamReader(fn))
        {
            string line;
    
            while ((line = await sr.ReadLineAsync()) != null)
            {
                //  manipulate the line 
                i++;
                await sw.WriteLineAsync(line);
                // every 500 lines, report progress
                if (i % 500 == 0)
                {
                    progress.Report(i);
                }
            }
        }
        return newFN;
    }
