    public class User
    {
        public string LogOn { get; set; }
    }
    public static class AppController
    {
        public static event PropertyChangedEventHandler StaticPropertyChanged;
        private static User currentUser;
        public static User CurrentUser
        {
            get { return currentUser; }
            set
            {
                currentUser = value;
                StaticPropertyChanged?.Invoke(null,
                    new PropertyChangedEventArgs(nameof(CurrentUser)));
            }
        }
    }
