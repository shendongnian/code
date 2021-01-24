    class TestViewModel:ViewModelBase
    {
        private TestModel model;
        public string DisplayValue
        {
            get { return model.displayValue; }
            set { SetIfChanged(ref model.displayValue, value); }
        }
        public void SetIfChanged(ref string field, string value)
        {
            if (field != value)
            {
                field = value;
                RaisePropertyChanged();
            }
        }
    }
