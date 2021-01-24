    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private bool _handleEvent = true;
        private void TextBox_PreviewGotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (!_handleEvent)
                return;
            bool loggedIn = ExecuteLogin(); //shows the login dialog and returns new login status
            if (!loggedIn)
            {
                CancelButton.Focus();
                e.Handled = true;
            }
        }
        public bool ExecuteLogin() => MessageBox.Show("Login?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes;
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("click");
        }
    }
----------
    <StackPanel>
        <TextBox  />
        <TextBox PreviewGotKeyboardFocus="TextBox_PreviewGotKeyboardFocus" />
        <TextBox />
        <Button x:Name="CancelButton" Content="Cancel" Click="CancelButton_Click" />
    </StackPanel>
