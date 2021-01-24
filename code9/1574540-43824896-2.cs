    public class Item
    {
        private int _id;
        public Item Child;
        public Item Parent;
        public int Id
        {
            get => _id;
            set
            {
                if (_id == value) //this is the guard
                    return;
                _id = value;
                if (Child != null)
                    Child.Id = _id;
                if (Parent != null)
                    Parent.Id = _id;
            }
        }
        public override string ToString() =>
            $"Id: {Id} child: ({Child?.ToString() ?? "-"})";
    }
