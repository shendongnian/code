    public class UserViewModel : INotifyPropertyChanged
    {
     private string _firstName = "";
     public string FirstName
     { 
         get { return _firstName; }
         set { _firstName = value; OnPropertyChanged(); }
     }
     public event PropertyChangedEventHandler PropertyChanged;
     private void OnPropertyChanged( [CallerMemberName] string propertyName = null )
     {
          PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( propertyName ) );
     }
}
