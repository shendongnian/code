     public static void Add<T>(this ObservableCollection<T> self, T itemToAdd, NotifyCollectionChangedEventHandler handler)
        {
            self.CollectionChanged -= handler;
            self.Add(itemToAdd);
            self.CollectionChanged += handler;
        }
