            string inputFile = "C:\\temp\\StreamWriterSample.txt";
            string tempFile = "C:\\temp\\StreamWriterSampleTemp.txt";
            using (StreamWriter sw = new StreamWriter(tempFile))//get a writer ready
            {
                using (StreamReader sr = new StreamReader(inputFile))//get a reader ready
                {
                    string currentLine = string.Empty;
                    while ((currentLine = sr.ReadLine()) != null)
                    {
                        if (currentLine.Contains("Clients"))
                        {
                            sw.WriteLine(currentLine + " modified");
                        }
                        else
                        {
                            sw.WriteLine(currentLine);
                        }
                    }
                }
            }
            //now lets crush the old file with the new file
            File.Copy(tempFile, inputFile, true);
