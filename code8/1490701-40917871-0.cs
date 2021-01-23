    public class Family
    {
        private readonly Parent _parent;
        private readonly ReadOnlyCollection<Child> _childs;
        public Family(Parent parent, IEnumerable<Child> childs)
        {
            _parent = parent;
            _childs = new ReadOnlyCollection<Child>(childs.ToList());
        }
    }
