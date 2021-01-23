    class CollectAndCommit : IDisposable
    {
        private Dictionary<string, bool> collectedStrings { get; set; }
        public CollectAndCommit()
        {
            collectedStrings = new Dictionary<string, bool>();
        }
        public void Collect(string collectedString)
        {
            collectedStrings.Add(collectedString, false);
        }
        public void CommitAllUncommitedStrings()
        {
            foreach (var uncommitedString in collectedStrings.Where(c => c.Value == false))
            {
                collectedStrings[uncommitedString.Key] = Commit(uncommitedString.Key);
            }
        }
        public bool HasUncommitedStrings()
        {
            return collectedStrings.Count(c => c.Value == false) > 0;
        }
        private bool Commit(string str)
        {
            try
            {
                string path = @"c:\temp\MyTest.txt";
                if (!File.Exists(path))
                {
                    File.Create(path);
                }
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(str);
                }	
                return true;
            }
            catch 
            {
                return false;
            }
        }
        public void Dispose()
        {
            if (HasUncommitedStrings())
            {
                throw new Exception("Uncommited Strings!");
            }
        }
    }
