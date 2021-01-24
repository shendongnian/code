     public bool IsReady
            {
                get { return _isReady; }
                set
                {
                    _isReady = value;
                    NotifyPropertyChanged("IsReady");
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        StartTaskCommand.RaiseCanExecuteChanged(); 
                    });
                }
            }
