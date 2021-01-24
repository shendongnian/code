     List<string> file1 = new List<string>();
            List<string> output = new List<string>();
            string differencesFile = path;
            File.WriteAllText(differencesFile, "");
            try
            {
                StreamReader readFile1 = new StreamReader(System.IO.File.OpenRead(pathfile1));
                
                string lineFile1;
                while ((lineFile1 = readFile1.ReadLine()) != null)
                {
                    bool match = false;
                    string[] colums = lineFile1.Split('\t');
                    StreamReader readFile2 = new StreamReader(System.IO.File.OpenRead(pathfile2));
                    string line2;
                    while ((line2 = readFile2.ReadLine()) != null)
                    {
                        string[] columsFile2 = line2.Split('\t');
                        if (colums[0] == columsFile2[0])
                        {
                            match = true;
                        }
                    }
                    if (!match)
                    {
                        
                        output.Add(colums[0] + "; doesnt exist in pathfile2");
                   
                        
                    }
                }
                System.IO.File.WriteAllLines(differencesFile, output);
            
            }
            catch { }
           
