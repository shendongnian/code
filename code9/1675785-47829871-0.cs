    public class HistoryItem
    {
        public HistoryItem this[int i]
        {
            get => Children[i];
            set => Children[i] = value;
        }
        public string Name { get; set; }
        public int Level { get; private set; }
        private HistoryItem _parent;
        public HistoryItem Parent {
            get => _parent;
            set
            {
                if (value == null)
                {
                    Level = 0;
                    _parent = null;
                }
                else
                {
                    Level = value.Level + 1;
                    _parent = value;
                }
            }
        }
        public IList<HistoryItem> Children { get; set; }
        
        public HistoryItem()
        {
            Name = "Parent";
            Level = 0;
            Parent = null;
            Children = new List<HistoryItem>();
        }
        public HistoryItem(string name)
        {
            Name = name;
            Level = 0;
            Parent = null;
            Children = new List<HistoryItem>();
        }
        public HistoryItem(HistoryItem parent)
        {
            Name = "Child";
            Level = parent.Level + 1;
            Parent = parent;
            Children = new List<HistoryItem>();
        }
        public HistoryItem(string name, HistoryItem parent)
        {
            Name = name;
            Level = parent.Level + 1;
            Parent = parent;
            Children = new List<HistoryItem>();
        }
        public void AddChild()
        {
            Children.Add(new HistoryItem("Child", this));
        }
        public void AddChild(string name)
        {
            Children.Add(new HistoryItem(name, this));
        }
        #region Overrides of Object
        public override string ToString()
        {
            return $"{Name} : Level: {Level}";
        }
        #endregion
    }
