       private void CheckFiles()
        {
            var fileGroups = new[] {
              new [] { "FG1A", "FG1B", "FG1C", "FG1D" },
              new[] { "FG2A", "FG2B", "FG2C", "FG2D", "FG2E" } };
            List<string> fileDates = new List<string>();
            List<string> pfiles = new List<string>();
            // get a list of file dates
            foreach (string fn in fileList)
            {
                string dateString = fn.Substring(fn.IndexOf('.'), 9);
                if (!fileDates.Contains(dateString))
                {
                    fileDates.Add(dateString);
                }
            }
            // check if a date has all the files
            foreach (string fd in fileDates)
            {
                int fgCount = 0;
                // for each file group
                foreach (Array masterfg in fileGroups)
                {
                    foreach (string fg in masterfg)
                    {
                        // see if all the files are there
                        bool foundIt = false;
                        string finder = fg + fd;
                        foreach (string fn in fileList)
                        {
                            if (fn.ToUpper().Contains(finder))
                            {
                                pfiles.Add(fn);
                            }
                        }
                        fgCount++;
                    }
                    if (fgCount == pfiles.Count())
                    {
                        foreach (string fn in pfiles)
                        {
                            procFileList.Add(fn);
                        }
                        pfiles.Clear();
                    }
                    else
                    {
                        pfiles.Clear();
                    }
                }
            }
            return;
        }
