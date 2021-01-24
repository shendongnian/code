    this.WebBox.Navigate.Navigate(URL1);
    while(this.WebBox.Navigate.ReadyState != WebBrowserReadyState.Complete)
    {
         Application.DoEvents();
    }
    this.WebBox.Navigate.Navigate(URL2);
    while(this.WebBox.Navigate.ReadyState != WebBrowserReadyState.Complete)
    {
         Application.DoEvents();
    }
    this.WebBox.Navigate.Navigate(URL3);
    while(this.WebBox.Navigate.ReadyState != WebBrowserReadyState.Complete)
    {
         Application.DoEvents();
    }
    //Done!
