            public bool CheckFile()
        {
            StreamReader sr = new StreamReader(File.Open(@"YourFilePath", FileMode.Open));
            string toCheck;
            using (sr)
            {
                toCheck = sr.ReadToEnd();
            }
            return toCheck.Contains("fileName");
        }
