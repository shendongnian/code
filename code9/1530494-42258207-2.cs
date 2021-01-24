    public class Window1ViewModel : INotifyPropertyChanged
    {
        public Window1ViewModel()
        {
            groups.CollectionChanged += (s, e) =>
            {
                if (e.NewItems != null)
                {
                    foreach (object item in e.NewItems)
                    {
                        (item as INotifyPropertyChanged).PropertyChanged
                            += new PropertyChangedEventHandler(item_PropertyChanged);
                    }
                }
                if (e.OldItems != null)
                {
                    foreach (object item in e.OldItems)
                    {
                        (item as INotifyPropertyChanged).PropertyChanged
                            -= new PropertyChangedEventHandler(item_PropertyChanged);
                    }
                };
            };
            var GroupA = new MyGroup("Group A");
            GroupA.Item.Add(new MyGroupItem("Item 1", 1.0));
            GroupA.Item.Add(new MyGroupItem("Item 2", 1.0));
            GroupA.Item.Add(new MyGroupItem("Item 3", 1.0));
            Groups.Add(GroupA);
            var GroupB = new MyGroup("Group B");
            GroupB.Item.Add(new MyGroupItem("Item 1", 1.0));
            GroupB.Item.Add(new MyGroupItem("Item 2", 1.0));
            GroupB.Item.Add(new MyGroupItem("Item 3", 1.0));
            Groups.Add(GroupB);
            currentItem = GroupA.Item[0];
        }
        private bool _handle = true;
        private void item_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (!_handle)
                return;
            MyGroup group = sender as MyGroup;
            CurrentItem = group.SelectedItem;
            //clear the selection in the other groups:
            _handle = false;
            foreach (MyGroup g in Groups)
                if (g != group)
                    g.SelectedItem = null;
            _handle = true;
        }
        protected ObservableCollection<MyGroup> groups = new ObservableCollection<MyGroup>();
        public ObservableCollection<MyGroup> Groups
        {
            get { return groups; }
        }
        protected MyGroupItem currentItem;
        public MyGroupItem CurrentItem
        {
            get { return currentItem; }
            set
            {
                if (currentItem == value) return;
                currentItem = value;
                NotifyPropertyChanged("CurrentItem");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
