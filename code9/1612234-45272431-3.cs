    @Html.DevExpress().GridView(settings =>
    {
        settings.Name = "preparedMessagesGrid";
    
        // other stuff
        settings.ClientSideEvents.SelectionChanged = "OnSelectionChanged";
    }).Bind(Model.preparedMessages).GetHtml()
