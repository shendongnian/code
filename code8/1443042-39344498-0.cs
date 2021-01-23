    // Remove:
    //gvc3.Header = "A2";
    // Replace by:
    gvc3.Header = new GridViewColumnHeader()
    {
        Content = "A2",
        ContextMenu = new ContextMenu()
        {
            Items =
            {
                new MenuItem() { Header="Asc"},
                new MenuItem() { Header="Desc"}
            }
        }
    };
