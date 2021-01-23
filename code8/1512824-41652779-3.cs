     void CrearBtnNews()
     {
        KinectTileButton botontest = new KinectTileButton
        {
            Style = FindResource("KinectTileButtonStyle1") as Style,
            Content = "WeB",
            Height = 265,
            Width = 450,
            Background = null,
            BorderBrush = null
        };
    
       botontest.Click += async (o, args) =>
       {
          Grid gridx = new Grid();
          await BrowserAsync();
          MessageBox.Show("working 8 seg");
       };
     }
    
    private async Task BrowserAsync()
    {
        // Do work here
        //
        await Task.Run(() => 
        {
            System.Threading.Thread.Sleep(8000);
        });
    }
