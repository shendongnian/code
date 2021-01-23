    Dictionary<string, string> fileAValues = LoadFile(@"C:\Temp\FileA.txt");
    Dictionary<string, string> fileBValues = LoadFile(@"C:\Temp\FileB.txt");
    
                using (StreamWriter sr = new StreamWriter(@"C:\Temp\FileC.txt"))
                {
                    foreach (string key in fileAValues.Keys)
                    {
                        if (fileBValues.ContainsKey(key))
                        {
                            string combined = key + "," + 
    
                              String.Join(",", fileAValues[key].ToString(),
                            fileBValues[key].ToString());  
                            sr.WriteLine(combined);
                        }
                    }
                }
