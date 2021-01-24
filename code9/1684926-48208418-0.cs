    static void SaveFiles(){
        List<Tasks> tasks = new List<Task>();
            try
            {
                    foreach (FileInfo file in files)
                    {
                        //The following is async function.
        				string fullName=file.FullName;
        				string name=file.Name;
        				tasks.Add(Task.Factory.StartNew(() => MakeAnalysisRequest(fullName, name)));
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
        
        static async Task MakeAnalysisRequest(string imageFilePath, string fileName)
        {
            //Here a list is populated.
            //List<string> Ids = new List<string();
            Ids.Add(obj.Id);
        }
