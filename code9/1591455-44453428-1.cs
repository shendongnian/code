    class MyViewModel
    {
        public string MyProp
        {
            get { return _MyProp; }
            set { SetAndNotifyIfChanged(ref _MyProp, value); }
        }
        private string _MyProp;
    }
