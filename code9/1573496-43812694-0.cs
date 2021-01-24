     if(Template10.Utils.DeviceUtils.Current().IsPhone()){
       var statusBar = Windows.UI.ViewManagement.StatusBar.GetForCurrentView();
       if(statusBar != null)
       {  
           if(Application.Current.RequestedTheme == ApplicationTheme.Light)
              //background && foreground or combination, and dependent on color choices
              statusBar.ForegroundColor = Windows.UI.Colors.Black;
          else if(Application.Current.RequestedTheme == ApplicationTheme.Dark
              statusBar.ForegroundColor = Windows.UI.Colors.White;
      }
    }
