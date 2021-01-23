    // Remove:
    //gvc3.Header = "A2";
    // Replace by:
    MenuItem item1 = New MenuItem();
    item1.Header = "Desc";
    //Event
    item1+= new RoutedEventHandler(this.someFunction_click);
    gvc3.Header = new GridViewColumnHeader()
    {
        Content = "A2",
    ContextMenu = new ContextMenu()
    {
        Items =
        {
            new MenuItem() { Header="Asc"},
            item1
        }
    }
    };
    //Function launched by the event
    private void someFunction_Click(object sender, System.EventArgs e)
    {
        //do something
    }
