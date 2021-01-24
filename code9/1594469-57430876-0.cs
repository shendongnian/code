    using Windows.UI.Xaml.Controls;    
    ....
    
    public async void DisplayDialog(string title, string message)
    {
        ContentDialog SaveData = new ContentDialog
           {
                Title = title,
                Content = message,
                CloseButtonText = "Ok"
           };
               ContentDialogResult result = await SaveData.ShowAsync();
     }
          
