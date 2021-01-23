    /*loop through each line of the csv file, add it the collection
                *and iterate the row number*/
                using (FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        string currentLine;
                        while ((currentLine = reader.ReadLine()) != null)
                        {
                            eachCSVLine.Add(rowNum, currentLine);
                            rowNum++;
                        }
                    }
                }
