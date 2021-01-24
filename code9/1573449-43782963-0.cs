    public class Room
    {
        public ObservableCollection<Wall> Walls { get; } = new ObservableCollection<Wall>();
        public Room()
        {
            Walls.CollectionChanged += Walls_CollectionChanged;
        }
        private void Walls_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    {
                        foreach (Wall w in e.NewItems)
                        {
                            w.Room = this;
                        }
                        break;
                    }
                case NotifyCollectionChangedAction.Remove:
                    {
                        foreach (Wall w in e.OldItems)
                        {
                            w.Room = null;
                        }
                        break;
                    }
            }
        }
    }
