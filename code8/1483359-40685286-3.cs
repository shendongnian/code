      public class MainViewModel : INotifiyPropertyChanged{
    
       private WindowStyle _windowStyle;
    
       public WindowStyle WinStyle {
        get{
       return _windowStyle;
           }
       set{
       _windowStyle = value;OnPropertyChanged("WinStyle");
       } 
      }
    }
