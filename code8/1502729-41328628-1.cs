    public static class AppCommandRepository {
        public static ICommand YourCommand { get; private set; }
        // You can also register other command as well.
        internal static void Initialize()
        {
            YourCommand = new YourCommand();                   
        }
    }
    
  
