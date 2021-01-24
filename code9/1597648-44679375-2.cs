    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(propertyName));
        }
    }
    public class ItemData : ViewModelBase
    {
        public string Name { get; set; }
        public string Age { get; set; }
        public string Mail { get; set; }
        private bool isSelected;
        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
                NotifyPropertyChanged();
            }
        }
    }
    public class ViewModel : ViewModelBase
    {
        public ObservableCollection<ItemData> Items { get; }
            = new ObservableCollection<ItemData>();
        private bool allSelected;
        public bool AllSelected
        {
            get { return allSelected; }
            set
            {
                allSelected = value;
                NotifyPropertyChanged();
                foreach (var item in Items)
                {
                    item.IsSelected = value;
                }
            }
        }
    }
