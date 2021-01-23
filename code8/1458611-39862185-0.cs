    public class MyViewModel : ViewModelBase 
    {
        public static MyViewModel Instance { get; set; }
        public static ICommand MyCommand { get; set; }
    
        public MyViewModel()
        {
            Instance = this;
        }
    }
