    public class B
    {
        public B()
        {
            Childs = new ObservableCollection<B>() { null };
        }
        public string Name { get; set; }
        private bool _isExpanded;
        public bool IsExpanded
        {
            get
            {
                return _isExpanded;
            }
            set
            {
                _isExpanded = value;
                if (_isExpanded)
                    LoadChilds();
            }
        }
        public ObservableCollection<B> Childs { get; set; }
        public void LoadChilds()
        {
            Childs.Clear();
            Childs.Add(new B() { Name = Guid.NewGuid().ToString() });
        }
    }
