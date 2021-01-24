    public class TrulyObservableCollection<T> : ObservableCollection<T> 
        where T : INotifyPropertyChanged
    {
        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            base.OnCollectionChanged(e);
            if (e.NewItems != null)
            {
                foreach (INotifyPropertyChanged inpc in e.NewItems)
                        inpc.PropertyChanged += Item_PropertyChanged;
            }
            if (e.OldItems != null)
            {
                foreach (INotifyPropertyChanged inpc in e.OldItems)
                        inpc.PropertyChanged -= Item_PropertyChanged;
            }
        }
        private void Item_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var index = IndexOf((T)sender);
            var args = new NotifyCollectionChangedEventArgs(
                action: NotifyCollectionChangedAction.Replace, 
                newItem: sender, 
                oldItem: sender, 
                index: index);
            //no need to call the override since we've already
            //subscribed to that item's PropertyChanged event
            base.OnCollectionChanged(args); 
        }
    }
