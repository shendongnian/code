    static void SaveFiles()
    {
        try
        {
            foreach (FileInfo file in files)
            {
                //The following is async function.
                MakeAnalysisRequest(file.FullName, file.Name).Wait(); // The only change
            }
    
            //The following needs to be called only after the MakeAnalysisRequest function has populated "Ids"
            if (Ids.Count > 1)
                CallBatchProcess(Ids);
    
            Console.WriteLine("Processing images...");
        }
        catch (Exception ex)
        {
            Console.WriteLine("There was an error! ");
        }
        Console.ReadLine();
    }
    
    static void async MakeAnalysisRequest(string imageFilePath, string fileName)
    {
        //Here a list is populated.
        //List<string> Ids = new List<string>();
        Ids.Add(obj.Id);
    }
