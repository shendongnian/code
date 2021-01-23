    public class Folder2
    {
    }
    
    public class Folder
    {
        public Folder2 folder { get; set; }
    }
    
    public class Collection
    {
        public List<Folder> folder { get; set; }
    }
    
    public class RootObject
    {
        public Collection collection { get; set; }
    }
