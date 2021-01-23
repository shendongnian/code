    @model List<SiteVM>
    ....
    @using (Html.BeginForm())
    {
        for(int i = 0; i < Model.Count; i++)
        {
            @Html.HiddenFor(m => m[i].ID)
            @Html.HiddenFor(m => m[i].Name)
            <label>
                @Html.CheckBoxFor(m => m[i].IsSelected)
                <span>@Model[i].Name</span>
            </label>
            @Html.ValidationMessage("Sites")
        }
        ....
    }
