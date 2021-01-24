    static async Task MakeAnalysisRequest(string imageFilePath, string fileName)
    {
        //Here a list is populated.
        // Some await statement
        //List<string> Ids = new List<string();
        Ids.Add(obj.Id);
    }
    static void SaveFiles()
    {
        try
        {
                var tasks = new List<Task>();
                foreach (FileInfo file in files)
                {
                    //The following is async function.
                    tasks.Add(MakeAnalysisRequest(file.FullName, file.Name));
                }
                Task.WaitAll(tasks.ToArray());
    
                //The following needs to be called only after the MakeAnalysisRequest function has populated "Ids"
                if (Ids.Count > 1)
                    CallBatchProcess(Ids);
    
                Console.WriteLine("Processing images...");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("There was an error! ");
        }
        Console.ReadLine();
    }
