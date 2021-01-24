        public interface INamedObject
        {
            string Name { get; set; }
        }
        public class FileObject : INamedObject
        {
            public string Name { get; set; }
        };
        public class FolderObject : ObservableCollection<INamedObject>, INamedObject
        {
            public string Name { get; set; }
        };
        FolderObject _root = new FolderObject() { Name = "root" };
        public FolderObject Root
        {
            get
            {
                return _root;
            }
        }
