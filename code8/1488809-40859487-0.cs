    class TestGeneric<T>
    {
        private ObservableCollection<T> _prop;
        public ObservableCollection<T> Prop
        {
            get
            {
                return _prop;
            }
            set
            {
                _prop = value;
                // here, I'll make process like 
                // value.GetType().GetProperties() etc.
            }
        }
    }
    class TestClass
    { }
