    public void InvokePropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                ThreadPool.QueueUserWorkItem(delegate
                {
                    originalContext.Post(delegate
                    {
                        handler(this, e);
                    }, null);
                });
            }
        }
