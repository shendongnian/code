    List<object> openedPages = new List<object>();
    private void ButtonProductionAuto_OnClick(object sender, RoutedEventArgs e)
    {
        var page = openedPages.FirstOrDefault(p => p.GetType().Equals(typeof(PageProductionAuto)));
        if(page == null)
        {
            page = new PageProductionAuto(someobject, this);
            opendPages.Add(page);
        }
        else
        {
            page.SetObjects(someobject, this); // create a method to set "someObject" to your page.
        }
        FrameMain.Content = page;
    }
