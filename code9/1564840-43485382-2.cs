    class TestViewModel:ViewModelBase
    {
        private TestModel model = new TestModel();
        public string DisplayValue
        {
            get { return model.displayValue; }
            set { SetIfChanged(ref model.displayValue, value); }
        }
        public void SetIfChanged(ref string field, string value, [CallerMemberName] string propertyName = null)
        {
            if (field != value)
            {
                field = value;
                RaisePropertyChanged(propertyName);
            }
        }
    }
