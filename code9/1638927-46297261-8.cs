    internal class ItemsClass : INotifyPropertyChanged
    {
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        private bool isFavorite;
        public bool IsFavorite
        {
            get { return isFavorite; }
            set { isFavorite = value; RaisePropertyChanged(nameof(IsFavorite)); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
