    using Windows.Phone.UI.Input;
    using Windows.UI.Popups;
    public sealed partial class App : Application
    {
        
        public App()
        {
            HardwareButtons.BackPressed += HardwareButtons_BackPressed;
        }
        
        private async void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
        {
            Frame frame = Window.Current.Content as Frame;
            if (frame == null) { return; }
            e.Handled = true;
            if (frame.CanGoBack) { frame.GoBack(); return; }
            else
            {
                string content = "Do you want to close the app?";
                string title = "Close Confirmation";
                MessageDialog confirmDialog = new MessageDialog(content, title);
                confirmDialog.Commands.Add(new UICommand("Yes"));
                confirmDialog.Commands.Add(new UICommand("No"));
                var confirmResult = await confirmDialog.ShowAsync();
                // "No" button pressed: Keep the app open.
                if (confirmResult != null && confirmResult.Label == "No") { return; }
                // "Back" or "Yes" button pressed: Close the app.
                if (confirmResult == null || confirmResult.Label == "Yes") { Current.Exit(); }
            }
        }
        
    }
