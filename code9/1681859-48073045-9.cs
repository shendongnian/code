    string url = ConfigurationManager.AppSettings["url_ws_local"];
    if(ApplicationDeployment.IsNetworkDeployed)
    {
      ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;
      if(ad.ActivationUri.AbsolutePath.Contains("prodservername"))
      {
        url = ConfigurationManager.AppSettings["url_ws_prod"];
      }
      else if ad.ActivationUri.AbsolutePath.Contains("testservername")
      .....
    }
    ws.Url = url;
