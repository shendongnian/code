     public partial class Window2 : Window
        {
            private Func<string, bool> mainWindowMethod;
    
            public Window2(Func<string, bool> displayMethod)
            {
                InitializeComponent();
                this.mainWindowMethod = displayMethod;
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                this.mainWindowMethod("Hello World");
            }
        }
