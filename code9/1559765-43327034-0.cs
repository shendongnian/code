    public abstract class ManagerBase
    {
        public List<ChildBase> ChildObjects { get; set; }
    }
    public abstract class Manager<T>
        : ManagerBase
        where T : ChildBase
    {
        public Manager()
        {
            ChildObjects = new List<T>();
        }
        public new List<T> ChildObjects
        {
            get { return base.ChildObjects.Cast<T>().ToList(); }
            set { base.ChildObjects = value.ToList<ChildBase>(); }
        }
    }
    public abstract class ChildBase
    {
        public ManagerBase ParentMgr { get; set; }
    }
    public abstract class Child<T>
        : ChildBase
        where T : ManagerBase
    {
        public Child(T parentMgr)
        {
            ParentMgr = parentMgr;
            ParentMgr.ChildObjects.Add(this);
        }
        public new T ParentMgr
        {
            get { return (T)base.ParentMgr; }
            set { base.ParentMgr = value; }
        }
    }
