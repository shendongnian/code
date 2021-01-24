    public class MyBindingList<I> : BindingList<I>
    {
        private readonly List<I> _baseList;
        public MyBindingList() : this(new List<I>())
        {
        }
        public MyBindingList(List<I> baseList) : base(baseList)
        {
            if(baseList == null)
                throw new ArgumentNullException();            
            _baseList = baseList;
        }
        public void AddRange(IEnumerable<I> vals)
        {
            ICollection<I> collection = vals as ICollection<I>;
            if (collection != null)
            {
                int requiredCapacity = Count + collection.Count;
                if (requiredCapacity > _baseList.Capacity)
                    _baseList.Capacity = requiredCapacity;
            }
            bool restore = RaiseListChangedEvents;
            try
            {
                RaiseListChangedEvents = false;
                foreach (I v in vals)
                    Add(v);
            }
            finally
            {
                RaiseListChangedEvents = restore;
                if (RaiseListChangedEvents)
                    ResetBindings();
            }
        }
    }
