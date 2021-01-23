    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    namespace App18
    {
        public sealed partial class MainPage : Page
        {
            public MainPage()
            {
                this.InitializeComponent();
            }
            private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
            {
                myTextBox.IsTabStop = true;
                myTextBox.Focus(FocusState.Programmatic);
            }
            private void MyTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
            {
                if (myTextBox.Text.ToLower().Contains("done"))
                {
                    myTextBox.IsTabStop = false;
                    myButton.Focus(FocusState.Programmatic);
                }
            }
        }
    }
