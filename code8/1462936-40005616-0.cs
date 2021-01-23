       ObservableCollection<ProfileModel> myObservable = new ObservableCollection<ProfileModel>();
                myObservable.CollectionChanged += (sender, e) =>
                {
                    if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
                    {
                        // do stuff
                    }
                };
