    public class TestPath
    {
        public FileInfo Original { get; private set; }
    
        public TestPath(FileInfo original)
        {
            Original = original;
        }
    
        public override string ToString()
        {
            return Path.GetFileNameWithoutExtension(Original.Name);
        }
    }
