    public abstract class ManagerBase
    {
        protected ManagerBase()
        {
            innerChildObjectList = new List<ChildBase>();
        }
        private IList innerChildObjectList;
        public IEnumerable<ChildBase> ChildObjects
        {
            get
            {
                foreach (ChildBase child in innerChildObjectList.OfType<ChildBase>())
                    yield return child;
            }
        }
        public void AddChild<T>(T child) where T : ChildBase
        {
            innerChildObjectList.Add(child);
        }
        public void RemoveChild<T>(T child) where T : ChildBase
        {
            innerChildObjectList.Remove(child);
        }
        public bool ContainsChild<T>(T child) where T : ChildBase
        {
            return innerChildObjectList.Contains(child);
        }
        //Add 'Insert', 'RemoveAt' methods if needed.
    }
    public abstract class Manager<T>
        : ManagerBase
        where T : ChildBase
    {
        public new IEnumerable<T> ChildObjects
        {
            get { return base.ChildObjects.OfType<T>(); }
        }
    }
    public abstract class ChildBase
    {
        protected ChildBase(ManagerBase mgr)
        {
            ParentMgr = mgr;
        }
        private ManagerBase parentMgr;
        public ManagerBase ParentMgr
        {
            get { return parentMgr; }
            set
            {
                if (parentMgr != null && parentMgr.ContainsChild(this))
                    parentMgr.RemoveChild(this);
                parentMgr = value;
                parentMgr.AddChild(this);
            }
        }
    }
    public abstract class Child<T>
        : ChildBase
        where T : ManagerBase
    {
        protected Child(T mgr) : base (mgr)
        {
        }
        public new T ParentMgr
        {
            get { return base.ParentMgr as T; }
            set { base.ParentMgr = value; }
        }
    }
