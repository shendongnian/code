            List<string> lines = new List<string>();
            using (StreamReader reader = new StreamReader(System.IO.File.OpenRead(path)))
            {
                string target = "";//the name of the column to skip
                int? targetPosition = null; //this will be the position of the column to 
               remove if it is available in the csv file
                string line;
                List<string> collected = new List<string>();
                while ((line = reader.ReadLine()) != null)
                {
                   
                        string[] split = line.Split(',');
                        collected.Clear();
                        
                        //to get the position of the column to skip
                        for (int i = 0; i < split.Length; i++)
                        {
                            if (string.Equals(split[i], target, StringComparison.OrdinalIgnoreCase))
                           {
                                targetPosition = i;
                                break; //we've got what we need. exit loop
                          }
                        }
                        //iterate and skip the column position if exist
                      
                        for (int i = 0; i < split.Length; i++)
                        {
                            if (targetPosition != null && i == targetPosition.Value) continue;
                            collected.Add(split[i]);
                        }
                       lines.Add(string.Join(",", collected));
                        
                    
                }
            }
            using (StreamWriter writer = new StreamWriter(path, false))
            {
                foreach (string line in lines)
                    writer.WriteLine(line);
            }
