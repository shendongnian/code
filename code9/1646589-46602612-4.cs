    public class ObservableItemCollection<T>
        : ObservableCollection<T> where T : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler ItemPropertyChanged;
        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            base.OnCollectionChanged(e);
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (INotifyPropertyChanged item in e.NewItems)
                    {
                        item.PropertyChanged += OnItemPropertyChanged;
                    }
                    break;
                case NotifyCollectionChangedAction.Remove:
                    foreach (INotifyPropertyChanged item in e.OldItems)
                    {
                        item.PropertyChanged -= OnItemPropertyChanged;
                    }
                    break;
                default:
                    break;
            }
        }
        private void OnItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            ItemPropertyChanged?.Invoke(this, e);
        }
    }
