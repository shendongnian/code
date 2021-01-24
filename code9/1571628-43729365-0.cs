    class Model : INotifyPropertyChanged
    {
        private MyClass _myClass;
        public MyClass MyClass
        {
            get { return _myClass; }
            set { _UpdateField(ref _myClass, value); }
        }
    }
