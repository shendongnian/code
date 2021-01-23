    <ul>
        @for (int i = 0; i < Model.sites.Count; i++)
        {
            <li>
                @Html.CheckBoxFor(m => m.sites[i].IsCheck, new { class = "parent" })
                @Html.LabelFor(m => m.sites[i].IsCheck, Model.sites[i].SiteName)
                @Html.HiddenFor(m => m.sites[i].SiteId)
                @Html.HiddenFor(m => m.sites[i].SiteName)
                <div> // suggest you style this to give a margin-left so its indented relative to the parent
                    for (int j = 0; j < Model.sites[i].Roomz.Count; j++)
                    {
                        @Html.CheckBoxFor(m => m.sites[i].Roomz[j].IsCheck, new { class = "child" })
                        @Html.LabelFor(m => m.sites[i].Roomz[j].IsCheck, Model.sites[i].Roomz[j].RoomName)
                        @Html.HiddenFor(m => m.sites[i].Roomz[j].RoomId)
                        @Html.HiddenFor(m => m.sites[i].Roomz[j].RoomName)
                    }
                <div>
            </li>
        }
    </ul>
