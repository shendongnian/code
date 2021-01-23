        private ICommand _MyCommand;
        public ICommand MyCommand
        {
            get { return _MyCommand ?? (_MyCommand = new DelegateCommand(a => MyCommandMethod(a))); }
        }
        private void MyCommandMethod(object item)
        {
            Console.WriteLine("Chosen element: " + (string)item);
        }
