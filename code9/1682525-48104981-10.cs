    public partial class WinMyWin : Window
    {
        public WinMyWin(MyViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
        }
    }
