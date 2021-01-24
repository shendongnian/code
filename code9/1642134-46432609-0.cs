    private async void HyperlinkButton_Click(object sender, RoutedEventArgs e)
    {
         PhoneCallStore phoneCallStore = await PhoneCallManager.RequestStoreAsync();
    
         Guid LineGuid = await phoneCallStore.GetDefaultLineAsync();
    
         PhoneLine phoneLine = await PhoneLine.FromIdAsync(LineGuid);
         phoneLine.Dial("+918888888888", "Some Name");
     }
