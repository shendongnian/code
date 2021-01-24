                string sourceDir = @"C:\SRCE\";
                string destinDir = @"C:\DIST\";
                string[] files = Directory.GetFiles(sourceDir);
                foreach (string file in files)
                {
                    using (StreamReader sr_ = new StreamReader
                    (sourceDir + Path.GetFileName(file)))
                    {
                        string res = string.Empty;
    
                        while(!sr_.EndOfStream)
                        {
                            var l = sr_.ReadLine();
    
                            if (l.Contains("recto"))
                            {
                                continue;
                            }
    
                            res += l + Environment.NewLine;
                        }
    
                        var streamWriter = File.CreateText(destinDir + Path.GetFileName(file));
                        streamWriter.Write(res);
                        streamWriter.Flush();
                        streamWriter.Close();
                    }
                }
