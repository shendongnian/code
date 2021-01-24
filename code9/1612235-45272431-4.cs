    @Html.DevExpress().PopupControl(settings =>
    {
        settings.Name = "pcModalMode";
        // other stuff
        settings.CallbackRouteValues = new { Controller = "Messages", Action = "Load" };
        settings.ClientSideEvents.BeginCallback = "OnPopUpBeginCallback";
        settings.ClientSideEvents.EndCallback = "OnPopUpEndCallback";
        // other stuff
    }).GetHtml()
