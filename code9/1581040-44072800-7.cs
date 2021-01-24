        private static void saveData()
        {
            using (StreamWriter outStream = new StreamWriter(outputFolder + @"\Data.json"))
            {
                // For each data record
                for (int i = 0; i < dataFile.Count; ++i)
                {
                    // split the record into fields
                    var dataArray = dataFile[i].Split(|);
                    outStream.WriteLine("{\n"); // start of record
                    // output each field
                    for (var 0 = 1; j < dataArray.Length; ++j)
                    {
                        if (j > 0)
                        {
                            outStream.WriteLine(","); // field separator
                        }
                        outStream.Write("\"" + labels[j] + "\"" + ": \"" dataArray[j+1] + "\"");
                    }
                    outStream.WriteLine();    // final field newline
                    outStream.WriteLine("}"); // and end of record
                }
            }
        }
