        public abstract class PersistentObjectBaseWithNameHierarchical<T> : PersistentObjectBaseWithName where T : PersistentObjectBaseWithNameHierarchical<T>
    {
        private PersistentObjectBaseWithNameHierarchical<T> _Parent;
        virtual public PersistentObjectBaseWithNameHierarchical<T> Parent
        {
            get
            {
                return _Parent;
            }
            set
            {
                _Parent = value;
                UpdatePropertiesInHierachy();
            }
        }
        [ForeignKey("Parent")]
        private ICustomList<PersistentObjectBaseWithNameHierarchical<T>> _ChildList = new CustomList<PersistentObjectBaseWithNameHierarchical<T>>();
        virtual public ICustomList<PersistentObjectBaseWithNameHierarchical<T>> ChildList
        {
            get
            {
                return _ChildList;
            }
            set
            {
                _ChildList = value;
                UpdatePropertiesInHierachy();
            }
        }
        public void AddChild(PersistentObjectBaseWithNameHierarchical<T> child)
        {
            if (ChildList.Count() != 0)
                child.OrderPosition = ChildList.Max(e => e.OrderPosition) + 1;
            ChildList.Add(child);
        }
        public void OrderChildList()
        {
            foreach (var e in ChildList)
            {
                e.OrderChildList();
            }
            ChildList.Sort((s1, s2) => s1.OrderPosition.CompareTo(s2.OrderPosition));
        }
        public int Level
        {
            get
            {
                if (Parent != null)
                {
                    return Parent.Level + 1;
                }
                else
                {
                    return 1;
                }
            }
        }
        private double _OrderPosition;
        virtual public double OrderPosition
        {
            get
            {
                if (_OrderPosition == 0)
                {
                    // We use the Id as OrderPosition to keep creation order by default
                    _OrderPosition = Id;
                }
                return _OrderPosition;
            }
            set
            {
                _OrderPosition = value;
                Parent?.ChildList.Sort((s1, s2) => s1.OrderPosition.CompareTo(s2.OrderPosition));
                UpdatePropertiesInHierachy();
            }
        }
        public void UpdatePropertiesInHierachy()
        {
            PersistentObjectBaseWithNameHierarchical<T> r = GetRoot(this);
            DuringUpdatePropertiesInHierachy();
        }
