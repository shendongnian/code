    public class BaseClass : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        protected void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged(this, e);
        }
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }
    }
