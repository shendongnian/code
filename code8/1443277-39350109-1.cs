        class Test : INotifyPropertyChanged
        {
            public int ID { get; set; }
            public string Name { get; set; }
            private bool _status;
            public bool Status
            {
                get { return _status; }
                set
                {
                    _status = value;
                    RaisePropertyChanged();
                }
            }
            #region INotifyPropertyChanged implementation
            public event PropertyChangedEventHandler PropertyChanged;
            private void RaisePropertyChanged([CallerMemberName]string propertyName = "")
            {
                Volatile.Read(ref PropertyChanged)?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
