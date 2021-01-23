    public class UserViewModel : INotifyPropertyChanged
    {
         private string _firstName = "";
         public string FirstName
         { 
             get { return _firstName; }
             set { _firstName = value; OnPropertyChanged(); }
         }
         public event PropertyChanged;
         private void OnPropertyChanged( [CallerMemberName] string propertyName )
         {
              PropertyChanged?.Invoke( this, new PropertyChanedEventArgs( propertyName ) );
         }
    }
