            string tempFile = Path.GetTempFileName();
            using (var sr = new StreamReader("NameList.txt"))
            using (var sw = new StreamWriter(tempFile))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Contains(searchFor))
                        sw.WriteLine(line);
                }
            }
            File.Delete("NameList.txt");
            File.Move(tempFile, "NameList.txt");
