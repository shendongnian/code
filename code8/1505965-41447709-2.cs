    public static class MySingletonIndex
    {
        private static IndexWriter writer;
        public static void Open(string path)
        {
            if (writer != null)
                throw new Exception("MySingletonIndex is already open");
            // ram directory is a nice option for early stages and experimentation.
            Directory d = path == null ? new RAMDirectory() : (Directory)FSDirectory.Open(path);
            writer = new IndexWriter(d, new WhitespaceAnalyzer(), IndexWriter.MaxFieldLength.UNLIMITED);
        }
        
        public static void Close()
        {
            if (writer == null) return;
            writer.Dispose();
            writer = null;
        }
        /// <summary>
        /// Caller must Dispose the IndexSearcher returned.
        /// </summary>
        /// <returns>IndexSearcher</returns>
        public static IndexSearcher GetSearcher()
        {
            if (writer == null)
                throw new Exception("MySingletonIndex is closed");
            return new IndexSearcher(writer.GetReader());           
        }
    }
