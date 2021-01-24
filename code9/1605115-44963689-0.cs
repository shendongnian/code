    private bool ProcessFile(string FolderPath, string FileExtension)
    {
        try
        {
            //all files with requisite file extension
            DirectoryInfo dinfo = new DirectoryInfo(FolderPath);
            FileInfo[] Files = dinfo.GetFiles(FileExtension);
            foreach (FileInfo file in Files)
            {
                List<String> AllLines = new List<String>();
                using (StreamReader sr = File.OpenText(file.FullName))
                {
                    int x = 0;
                    while (!sr.EndOfStream)
                    {
                        AllLines.Add(sr.ReadLine());
                        x += 1;
                    }
                    sr.Close();
                } 
                    
    			Parallel.For(0, AllLines.Count, x =>
    			{ 
    				InsertDataCheck(AllLines[x]);
    			}); 
                
            }
            GC.Collect();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return false;
    }
    
    private void InsertDataCheck(string Line)
    {
       //check if you want to insert data on the basis of your condition
       //and then insert your data    
    }
