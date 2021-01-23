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
        await Application.Current.Dispatcher.BeginInvoke((Action)() =>
        {
            // Create UI components here. If there is only one component, 
            // there is no need to wrap it in a BeginInvoke.
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
