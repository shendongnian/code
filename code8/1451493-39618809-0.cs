    public class DeferredData<T> : INotifyPropertyChanged
    {
        public DeferredData(T cachedData, Task<T> dataFactory)
        {
            _data = cachedData;
            DatabaseLookupTask = dataFactory.ContinueWith(task => Data = task.Result, CancellationToken.None, TaskContinuationOptions.RunContinuationsAsynchronously,
                TaskScheduler.FromCurrentSynchronizationContext());
        }
        private T _data;
        public T Data
        {
            get { return _data; }
            private set
            {
                if (Equals(value, _data)) return;
                _data = value;
                OnPropertyChanged();
            }
        }
        public Task DatabaseLookupTask { get; }
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
