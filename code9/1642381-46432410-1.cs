            List<string> databaseFiles = new List<string>(Directory.GetFiles("X:\\Private\\DATA\\PROJECT DATA\\Database"));
            List<string> filesToSearch = new List<string>(Directory.GetFiles("X:\\Private\\DATA\\PROJECT DATA\\FilesToSearch"));
            foreach(var item in listFiles)
            {
                var curFile = Path.Combine("X:\\Private\\DATA\\PROJECT DATA\\Database\\", item);
                var copyFrom = Path.Combine("X:\\Private\\DATA\\PROJECT DATA\\CopyFrom\\", item);
                if (databaseFiles.Contains(curFile))
                {
                    existsAlready.Add(item);
                }
                else
                {
                    if (filesToSearch.Contains(copyFrom))
                    {
                        File.Copy(copyFrom, curFile, true);
                        existsAdded.Add(item);
                    }
                    else
                    {
                        existsNegative.Add(item);
                    }
                }
            }
