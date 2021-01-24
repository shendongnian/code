    public class PropertyChangedEventManager
    {
        public void AddHandler(
            INotifyPropertyChanged source,
            EventHandler<PropertyChangedEventArgs> handler,
            string propertyName)
        {
            source.PropertyChanged += (s, e) => {
                if (e.PropertyName == propertyName)
                    handler(s, e);
            };
        }
    }
