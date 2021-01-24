     public class HomePageViewModel : INotifyPropertyChanged
     {
         public event PropertyChangedEventHandler PropertyChanged;
         public void OnPropertyChanged([CallerMemberName] string PropertyName = null)
         {
             this.PropertyChanged(this,new PropertyChangedEventArgs(PropertyName));
         }
    
         private bool _isSelected;
         public bool IsSelected
         {
             get { return _isSelected; }
             set
             {
                 _isSelected = value;
                 OnPropertyChanged();
             }
         }
    
         private Command _trigger;
         public Command Trigger
         {
             get
             {
                 return _trigger
                     ?? (_trigger = new Command(
                     () =>
                     {
                         IsSelected = !IsSelected;
                     }));
             }
         }
     }
