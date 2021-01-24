    <Style TargetType="{x:Type TreeViewItem}">
        <Setter Property="IsSelected" Value="{Binding IsSelected}" />
    </Style>
----------
    public class DirectoryItem : INotifyPropertyChanged
    {
        public String DisplayName { get; set; }
        public String Fullpath { get; set; }
        public ObservableCollection<DirectoryItem> Children { get; set; }
        private bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set { _isSelected = value; NotifyPropertyChanged(); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
