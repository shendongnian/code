     public abstract class BaseViewModel : INotifyPropertyChanged
    {
        //MEMBERS
        public event PropertyChangedEventHandler PropertyChanged;
        //PROPERTIES
        public void OnPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
