    public class MyViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private bool favorite;
        public bool Favorite
        {
            get { return favorite; }
            set
            {
                if (value != favorite)
                {
                    favorite = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
