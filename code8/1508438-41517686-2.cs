    class ViewModelMain : ViewModelBase, INotifyPropertyChanged
    {
        private delegate void UpdateText(ViewModelMain vm);
        private string _textProperty;
        public string TextProperty
        {
            get { return _textProperty; }
            set
            {
                if (_textProperty != value)
                {
                    _textProperty = value;
                    RaisePropertyChanged("TextProperty");
                }
            }
        }
        public ViewModelMain()
        {
            TextProperty = "Type here";
            for (int i = 1; i <= 5; i++)
            {
                var sleep = 10000 * i;
                var copy = i;
                var updateTextDelegate = new UpdateText(vm =>
                    vm.TextProperty = string.Format("New Value #{0}", copy));
                new System.Threading.Thread(() =>
                {
                    System.Threading.Thread.Sleep(sleep);
                    updateTextDelegate.Invoke(this);
                }).Start();
            }
        }
    }
