    public class BindableBase : INotifyPropertyChanged
    {
        private readonly List<(SynchronizationContext context, PropertyChangedEventHandler handler)> _handlers = new List<...>();
        public event PropertyChangedEventHandler PropertyChanged
        {
            add => _handlers.Add((SynchronizationContext.Current, value));
            remove
            {
                var i = 0;
                foreach (var item in _handlers)
                {
                    if (item.handler.Equals(value))
                    {
                        _handlers.RemoveAt(i);
                        break;
                    }
                    i++;
                }
            }
        }
        protected Task RaisePropertyChanged(string propertyName)
        {
            var args = new PropertyChangedEventArgs(propertyName);
            var tasks = _handlers
                .GroupBy(x => x.context, x => x.handler)
                .Select(g => invokeContext(g.Key, g));
            return Task.WhenAll(tasks);
            Task invokeContext(SynchronizationContext context, IEnumerable<PropertyChangedEventHandler> l)
            {
                if (context != null)
                {
                    var tcs = new TaskCompletionSource<bool>();
                    context.Post(o =>
                    {
                        try { invokeHandlers(l); tcs.TrySetResult(true); }
                        catch (Exception e) { tcs.TrySetException(e); }
                    }, null);
                    return tcs.Task;
                }
                else
                {
                    return Task.Run(() => invokeHandlers(l));
                }
            }
            void invokeHandlers(IEnumerable<PropertyChangedEventHandler> l)
            {
                foreach (var h in l)
                    h(this, args);
            }
        }
    }
