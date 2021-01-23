    @for (int i = 0; i < Model.sites.Count; i++)
    {
        // Generate the sites
        @Html.CheckBoxFor(m => m.sites[i].IsCheck)
        // @Model.sites[i].SiteName
        @Html.LabelFor(m => m.sites[i].IsCheck, Model.sites[i].SiteName)
        @Html.HiddenFor(m => m.sites[i].SiteId)
        @Html.HiddenFor(m => m.sites[i].SiteName)
        // Generate the rooms for each site
        @for(int j = 0; j < Model.sites[i].Rooms.Count; j++)
        {
            @Html.CheckBoxFor(m => m.sites[i].Rooms[j].IsCheck)
            @Html.LabelFor(m => m.sites[i].Rooms[j].IsCheck, Model.sites[i].Rooms[j].RoomName)
            @Html.HiddenFor(m => m.sites[i].Rooms[j].RoomId)
            @Html.HiddenFor(m => m.sites[i].Rooms[j].RoomName)
        }
    }
    
