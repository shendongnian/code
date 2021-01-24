    try
       {
        axMsRdpClient.Server = ServerName;
    
        axMsRdpClient.DesktopHeight = 768;
        axMsRdpClient.DesktopWidth = 1024;
        axMsRdpClient.Connect();
       }
       catch (Exception Ex)
       {
        MessageBox.Show(Ex.Message);
       }
