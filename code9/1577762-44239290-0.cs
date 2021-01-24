    [NotifyPropertyChanged]
    public class ObservableCollectionEx<T> : ObservableCollection<T>
    {
        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (T item in e.OldItems)
                {
                    ((INotifyPropertyChanged)item).PropertyChanged -= OnItemPropertyChanged;
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (T item in e.NewItems)
                {
                    ((INotifyPropertyChanged)item).PropertyChanged += OnItemPropertyChanged;
                }
            }
            base.OnCollectionChanged(e);
        }
        protected void OnPropertyChanged(string propertyName)
        {
            base.OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }
        protected void OnItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            NotifyPropertyChangedServices.SignalPropertyChanged(this, "Item[]");
            NotifyCollectionChangedEventArgs collectionChangedEventArgs = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset);
            base.OnCollectionChanged(collectionChangedEventArgs);
        }
    }
