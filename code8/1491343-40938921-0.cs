    public class FirstViewModel : IWindowCloseNotifier {
    
       public SecondViewModel SecondVm { get; set; }
    
        public FirstViewModel() 
        {
          SecondVm = new SecondViewModel(this);  
        }
    
        public void Close(IWindowCloseNotifierArgs args)
        {
           // Window is now closed!
        }
    }
    
