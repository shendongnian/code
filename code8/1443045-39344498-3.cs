    gvc3.Header = new GridViewColumnHeader()
    {
        Content = "A2",
        ContextMenu = new ContextMenu()
        {
            Items =
            {
                CreateAscendingSortMenuItem("a2"),
                CreateDescendingSortMenuItem("a2")
            }
        }
    };
