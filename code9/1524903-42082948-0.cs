    RangeObservableCollection<IEntity> IEntityListViewModel.Items
        {
            get
            {
                return new RangeObservableCollection<IEntity>(Items.Cast<IEntity>());
            }
            set
            {
                Items = new RangeObservableCollection<T>(value.Cast<T>());
            }
        }
        IEntity IEntityListViewModel.SelectedItem
        {
            get
            {
                return SelectedItem;
            }
            set
            {
                SelectedItem = (T)value;
            }
        }
