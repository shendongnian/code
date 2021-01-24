    var tempFile = Path.GetTempFileName();
                List<string> linesToKeep = new List<string>();
                using (FileStream fs = new FileStream(path(), FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        while (!sr.EndOfStream)
                        {
                            string currentline = sr.ReadLine().ToString();
                            string splitline = currentline;
                            if (splitline.Split(';')[0] != ID) //split the line and add your personal identifier so it knows what to keep and what to delete.
                            {
                                linesToKeep.Add(currentline);
                            }
                        }
                    }
                }
                File.WriteAllLines(tempFile, linesToKeep);
                File.Delete(path());
                File.Move(tempFile, path());
