    public class FileNameComparer : IEqualityComparer<FileInfo>
    {
        public bool Equals(FileInfo x, FileInfo y)
        {
            //Here is where the magic is happening.
            return x.Name == y.Name;
        }
        //You need this too, altougt, I am not quite sure when it gets used.
        public int GetHashCode(FileInfo obj)
        {
            
            return obj.Name.GetHashCode();
        }
    }
