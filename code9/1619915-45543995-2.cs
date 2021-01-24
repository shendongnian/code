    <DataGridTemplateColumn.Header>
        <CheckBox Content="Included"
                    x:Name="headerCheckBox"
                    IsChecked="{Binding DataContext.AllChecked, RelativeSource={RelativeSource AncestorType=DataGrid}}"/>
    </DataGridTemplateColumn.Header>
----------
    public class ViewModel : INotifyPropertyChanged
    {
        public ViewModel()
        {
            Items = new ObservableCollection<Item>();
            Items.CollectionChanged += Items_CollectionChanged;
            //add the items..:
            Items.Add(new Item());
            Items.Add(new Item() { IsChecked = true });
            Items.Add(new Item());
        }
        private void Items_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (object item in e.NewItems)
                {
                    (item as INotifyPropertyChanged).PropertyChanged += new PropertyChangedEventHandler(item_PropertyChanged);
                }
            }
            if (e.OldItems != null)
            {
                foreach (object country in e.OldItems)
                {
                    (country as INotifyPropertyChanged).PropertyChanged -= new PropertyChangedEventHandler(item_PropertyChanged);
                }
            }
        }
        private void item_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged("AllChecked");
        }
        public ObservableCollection<Item> Items { get; private set; }
        public bool AllChecked
        {
            get { return Items.All(x => x.IsChecked); }
            set
            {
                foreach (var item in Items)
                    item.IsChecked = value;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
