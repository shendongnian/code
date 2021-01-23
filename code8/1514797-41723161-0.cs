        public class Data
        {
            public ObservableCollection<String> InnerCollection { get; set; }
        }
        public class collection : ObservableCollection<Data>
        {
            protected override void InsertItem(int index, Data item)
            {
                item.InnerCollection.CollectionChanged += InnerCollection_CollectionChanged;
                base.InsertItem(index, item);
            }
            private void InnerCollection_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
            {
                //Actually it does not make any sense. You may need to construct something special. But firing an event it would be enough
                OnCollectionChanged(e);
            }
            protected override void RemoveItem(int index)
            {
                var date = base.Items[index];
                date.InnerCollection.CollectionChanged -= InnerCollection_CollectionChanged;
                base.RemoveItem(index);
            }
        }
