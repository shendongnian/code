    public class UserSettings : INotifyPropertyChanged
    {
       private double _fontSize = 20;
       public double FontSize
       {
           get { return _fontSize; }
           set { _fontSize = value; OnPropertyChanged(); }
       }
    
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
