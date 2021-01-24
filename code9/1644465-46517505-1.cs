    namespace WpfApp2
    {
        public abstract class FileSystemElement : IFileSystemElement
        {
            protected FileSystemElement(string name)
            {
                Name = name;
            }
    
            public string Name { get; }
    
            public override string ToString()
            {
                return Name;
            }
        }
    }
