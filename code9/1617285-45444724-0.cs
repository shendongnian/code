        private static List<string> ReadFile(string path)
        {
            List<string> records = new List<string>();
            using (StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                    records.Add(sr.ReadLine());
            }
            return records;
        }
