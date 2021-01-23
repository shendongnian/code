    public string[] GetDataLinesFromFile(string filename, string searchString)
        {
            List<string> dataEntries = new List<string>();
            using (System.IO.StreamReader stream = new System.IO.StreamReader(filename))
            {
                System.IO.TextReader tr = stream;
                bool foundSearchString = false;
                string lastLine = string.Empty;
                string line = string.Empty;
                while (!stream.EndOfStream)
                {
                    lastLine = line;
                    line = tr.ReadLine();
                    if (lastLine.Trim().StartsWith(searchString) && line.Contains("===================="))
                    {
                        foundSearchString = true;
                        continue;
                    }
                    if (foundSearchString)
                    {
                        // Start after the divider line
                        if (lastLine.Contains("===================="))
                            continue;
                        // If the current line read is a marker line, then our last line is actually a new identifier line
                        if (line.Contains("===================="))
                        {
                            // Can be used to look for multiple listings with the same ID
                            foundSearchString = false;
                            continue;
                            // If you only want the first found ID, uncomment this and comment out above
                            // return dataEntries.ToArray();
                        }
                        // If our previously read line is not empty, add it to the list of strings
                        if (lastLine.Trim().Length != 0)
                            dataEntries.Add(lastLine);
                    }
                }
            }
            return dataEntries.ToArray();
        }
