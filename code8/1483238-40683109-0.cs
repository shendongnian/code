     (((dynamic)DataContext).foo as ObservableCollection<object>).CollectionChanged += (s, e) =>
            {
                if (e.Action == NotifyCollectionChangedAction.Replace)
                {
                    
                }
                else
                {
                   //and so on
                }
            };
