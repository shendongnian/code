    public partial class SecondaryWin : Window
    {
        DeleteRow callbackDel;
        public SecondaryWin(DeleteRow callback)
        {
            InitializeComponent();
            callbackDel = callback;
        }
        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            callbackDel.Invoke(true);
            // Close the window
        }
    }
