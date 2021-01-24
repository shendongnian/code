    this.WebBox.Navigate(URL1);
    while(this.WebBox.Navigate.ReadyState != WebBrowserReadyState.Complete)
    {
         Application.DoEvents();
    }
    this.WebBox.Navigate(URL2);
    while(this.WebBox.Navigate.ReadyState != WebBrowserReadyState.Complete)
    {
         Application.DoEvents();
    }
    this.WebBox.Navigate(URL3);
    while(this.WebBox.Navigate.ReadyState != WebBrowserReadyState.Complete)
    {
         Application.DoEvents();
    }
    //Done!
