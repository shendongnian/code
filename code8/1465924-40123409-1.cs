infoPage
    private void txttext_TextChanged(object sender, TextChangedEventArgs e)
    {
        ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
        localSettings.Values["texboxtext"] =txttext.Text; // example value            
    }
MainPage
     private void btngetsecondpage_Click(object sender, RoutedEventArgs e)
     { 
         ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
         if (localSettings.Values["texboxtext"] != null)
         {
             txtresult.Text = localSettings.Values["texboxtext"].ToString();
         }
     }
