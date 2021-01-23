    private void Operations_Changed(object sender, NotifyCollectionChangedEventArgs e)
    {
        if (App.Operations.Count == 0)
        {
            _totalBytes = 0;
            _writtenBytes = 0;
            _bytesOfCompletedOperations = 0;
        }
        else
        {
            if (e.NewItems?.Count > 0)
                foreach (OperationVM item in e.NewItems)
                    _totalBytes += item.Bytes;
            if (e.OldItems?.Count > 0)
                foreach (OperationVM item in e.OldItems)
                    _bytesOfCompletedOperations += item.Bytes;
        }
    }
