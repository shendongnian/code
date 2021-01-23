      public class MainViewModel : INotifiyPropertyChanged{
    
       private WindowStyle _windowStyle;
    
       public WindowStyle WinStyle {
        get{
       return _windowStyle ?? (_windowStyle == WindowStyle.None));
           }
       set{
       _windowStyle = value;OnPropertyChanged("WinStyle");
       } 
      }
    }
