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
          await BrowserAsync();
       };
     }
    
    private async Task BrowserAsync()
    {
        await Application.Current.Dispatcher.InvokeAsync((Action)() =>
        {
            // Create UI components here
            //
            Grid gridx = new Grid();
        });
    
        // Do work here
        //
        await Task.Run(() => 
        {
            System.Threading.Thread.Sleep(8000);
        });
    
        MessageBox.Show("working 8 seg");
    }
