    class BaseClass
    {
        internal Class1 class1List;
        private List<Class1> _class1List;
        public List<Class1> Class1List
        {
            get
            {
                return _class1List;
                // return new List<Class1> { class1List };
            }
            set
            {
                class1List = value.First();
                _class1List = value;
            }
        }
    }
