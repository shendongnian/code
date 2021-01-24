     private async void ButtonStartClick(object sender, RoutedEventArgs e)
     {
         myButton.IsEnabled = false;
         await RunTask();
         myButton.IsEnabled = true;
     }
