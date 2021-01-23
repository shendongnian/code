        <ul>
    @for (int i = 0; i < Model.sites.Count; i++)
    {
        <li>
            @Html.CheckBoxFor(m => m.sites[i].IsCheck)
            @Html.LabelFor(m => m.sites[i].IsCheck, Model.sites[i].SiteName)
            @Html.HiddenFor(m => m.sites[i].SiteId)
            @Html.HiddenFor(m => m.sites[i].SiteName)
              <ul>
                   for (int j = 0; j < Model.sites[i].Roomz.Count; j++)
                  {
                    <li>
                       @Html.CheckBoxFor(m => m.sites[i].Roomz[j].IsCheck)
                       @Html.LabelFor(m => m.sites[i].Roomz[j].IsCheck,Model.sites[i].Roomz[j].RoomName)
                       @Html.HiddenFor(m => m.sites[i].Roomz[j].RoomId)
                       @Html.HiddenFor(m => m.sites[i].Roomz[j].RoomName)
                   </li>
                  }    
             </ul>
          </li>
       
        }
         </ul>
