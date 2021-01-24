    public class FolderNode : INode<Folder>
    {
        private readonly Folder _folder = new Folder();
        public Folder Build()
        {
            return _folder;
        }
        public void AppendGroup()
        {
            _folder.Path.AppendLine("Folder Group");
        }
        public void AppendFolder()
        {
            _folder.Path.AppendLine("Folder Folder");
        }
    }
    public class UserNode : INode<User>
    {
        private readonly User _user = new User();
        public User Build()
        {
            return _user;
        }
        public void AppendGroup()
        {
            _user.Path.AppendLine("Group");
        }
        public void AppendFolder()
        {
            _user.Path.AppendLine("Folder");
        }
    }
    public class CommonBuilder<T, TNode> where TNode : INode<T>
    {
        private readonly TNode _root;
        public CommonBuilder(TNode root)
        {
            _root = root;
        }
        public T Build()
        {
            return _root.Build();
        }
        public CommonBuilder<T, TNode> Group {
            get
            {
                _root.AppendGroup();
                return this;
            }
        }
        public CommonBuilder<T, TNode> Folder {
            get
            {
                _root.AppendFolder();
                return this;
            }
        }
        
    }
    public interface INode<out T>
    {
        T Build();
        void AppendGroup();
        void AppendFolder();
    }
    public class Folder
    {
        public StringBuilder Path { get; } = new StringBuilder();
        public override string ToString()
        {
            return Path.ToString();
        }
    }
    public class User
    {
        public StringBuilder Path { get; } = new StringBuilder();
        public override string ToString()
        {
            return Path.ToString();
        }
    }
