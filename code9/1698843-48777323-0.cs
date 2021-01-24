    class Class2
    {
        private ICommand _ChangeValue;
        public ICommand ChangeValue
        {
            get
            {
                if (_ChangeValue == null)
                {
                    _ChangeValue = new RelayCommand<object>(Execute_ChangeValue, CanExecute_ChangeValue);
                }
    
                return _ChangeValue;
            }
        }
        // NOTE: not observable, due to lack of INotifyPropertyChanged.
        // It's fine in this scenario, but don't expect to be able to change
        // this value and have bindings update automatically.
        private Class1 _class1;
        public Class1 Class1
        {
            get { return _class1; }
            set { _class1 = value; }
        }
        public bool CanExecute_ChangeValue(object parameter)
        {
            return true;
        }
        public void Execute_ChangeValue(object parameter)
        {
            Console.WriteLine($"Execute_ChangeValue");
    
            Class1.MyProperty = 5;
    
            Console.WriteLine($"Class1.MyProperty: {Class1.MyProperty }");
        }
    }
