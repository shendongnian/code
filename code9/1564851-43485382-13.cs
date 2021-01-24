    class TestViewModel:ViewModelBase
    {
        private TestModel model = new TestModel();
        public string DisplayValue
        {
            get { return model.displayValue; }
            set { SetIfChanged(ref model.displayValue, value, RunCalculations); }
        }
        public bool SetIfChanged<T>(ref T field, T value, Action MoreWork, [CallerMemberName] string propertyName = null)
        {
            if (!Equals(field, value))
            {
                field = value;
                MoreWork.Invoke();
                RaisePropertyChanged(propertyName);
                return true;
            }
            return false;
        }
        private void RunCalculations()
        {
           // Do some work before RaisePropertyChanged()
        }
    }
