           private List<List<string>> getFileInfo()
            {
                List<List<string>> arFiles = new List<List<string>>();
                string[] oFiles = Directory.GetFiles(sPath, "*.csv");
                nColumns = 4;
                List<string> newRow = null;
                for(int index = 0; index < oFiles.Count(); index++)
                {
                    if ((index % nColumns) == 0)
                    {
                        newRow = new List<string>();
                        arFiles.Add(newRow);
                    }
                    newRow.Add(oFiles[index]);
                }
                return arFiles;
            }
