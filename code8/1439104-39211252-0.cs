           private void PopulateList(string path)
        {
            List<string> files = new List<string>();
            foreach (string str in System.IO.Directory.GetFiles(path, "*.jpg"))
                files.Add(str);
            if (files.Count > 0)
                this.m_Files.Add(path, files);
            foreach (string str in System.IO.Directory.GetDirectories(path))
                this.PopulateList(str);
        }
