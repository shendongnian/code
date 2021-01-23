        public abstract class PersistentObjectBaseWithNameHierarchical <T> 
    {
        private T _Parent;
        virtual public T Parent
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
        private ICustomList<T> _ChildList = new CustomList<T>();
        virtual public ICustomList<T> ChildList
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
