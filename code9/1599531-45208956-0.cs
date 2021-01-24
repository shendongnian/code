    private bool? _firstLoadJustPassed;
    private async Task<LoadMoreItemsResult> LoadMoreItemsAsync(uint count, CancellationToken cancellationToken)
    {
        if (_firstLoadJustPassed == true)
        {
            _firstLoadJustPassed = false;
            return new LoadMoreItemsResult { Count = 0 };
        }
    
        uint resultCount = 0;
        _cancellationToken = cancellationToken;
    
        try
        {
            if (!_cancellationToken.IsCancellationRequested)
            {
                IEnumerable<IType> data = null;
                try
                {
                    IsLoading = true;
                    data = await LoadDataAsync(_cancellationToken);
                }
                catch (OperationCanceledException)
                {
                    // The operation has been canceled using the Cancellation Token.
                }
                catch (Exception ex) when (OnError != null)
                {
                    OnError.Invoke(ex);
                }
    
                if (data != null && data.Any() && !_cancellationToken.IsCancellationRequested)
                {
                    resultCount = (uint)data.Count();
    
                    foreach (var item in data)
                    {
                        Add(item);
                    }
    
                    if (!_firstLoadJustPassed.HasValue)
                    {
                        _firstLoadJustPassed = true;
                    }
                }
                else
                {
                    HasMoreItems = false;
                }
            }
        }
        finally
        {
            IsLoading = false;
    
            if (_refreshOnLoad)
            {
                _refreshOnLoad = false;
                await RefreshAsync();
            }
        }
    
        return new LoadMoreItemsResult { Count = resultCount };
    }
