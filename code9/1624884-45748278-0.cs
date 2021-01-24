     public partial class MainWindow : Window
        {
    
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private bool DisplayText(string displayText)
            {
                txt_Main.Text = displayText;
                return true;
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                Window2 win2 = new Window2(DisplayText);
                win2.ShowDialog();
            }
        }
