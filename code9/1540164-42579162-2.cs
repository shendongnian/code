     public event EventHandler Notify;
    
        private void OnNotify(object sender)
        {
            Notify?.Invoke(sender, new EventArgs());
        }
    
        public ICommand NotifyCommand => new DelegateCommand<object>(OnNotify);
