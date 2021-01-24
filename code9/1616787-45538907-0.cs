    private async void delete_click(object sender, RoutedEventArgs e)
    {
            StorageFile file = await ApplicationData.Current.LocalFolder.GetFileAsync("temp1.jpg");
            if (filed != null)
            {
                await filed.DeleteAsync();
            }
    }
