    public class MainWindowViewModel : ViewModelBaseOrWhatever
    {
        //  If MainWindowViewModel has no public constructors, no other class can create an 
        //  instance of it. This is a requirement you need to enforce, so and you can make 
        //  the compiler enforce it for you. If you had done this, the compiler would have 
        //  found this bug for you as soon as you wrote it. 
        private MainWindowViewModel()
        {
            //  ...whatever...
        }
        static MainWindowViewModel()
        {
            Instance = new MainWindowViewModel();
        }
        public static MainWindowViewModel Instance { get; private set; }
    }
