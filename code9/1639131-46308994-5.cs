    public class CommonBuilder<T> : IGroup<T>, IFolder<T> where T: INode, new()
    {
        private T _root = new T();
        public T Build()
        {
            return _root;
        }
        public IGroup<T> Group
        {
            get
            {
                _root.MoveToGroup();
                return this;
            }
        }
        public IFolder<T> Folder
        {
            get
            {
                _root.MoveToFolder();
                return this;
            }
        }
    }
