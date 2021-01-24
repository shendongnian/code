    public async void Button_Click(object sender, RoutedEventArgs e)
    {
        string locationA = Ntaban.Api.API_server.Host + "/content/profile/";
        string locationB = St_Major.Directories.Directory_Main;
        string name = lst.First().picAdr;
        BitmapImage bitMapImage = await Task.Run(async () => await savefile.Set_Image(locationA, locationB, name));
        imgProfile.Source = bitMapImage;
    }
