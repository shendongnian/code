    foreach (string line in first10Lines)
            {
            File.AppendAllText(newPathName, line);
            File.AppendAllText(newPathName, string.Format("{0}{1}", " ", Environment.NewLine));
            }
