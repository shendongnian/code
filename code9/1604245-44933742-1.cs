    public void InvokePropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                _originalContext.Post(delegate
                {
                    handler(this, e);
                }, null);
            }
        }
