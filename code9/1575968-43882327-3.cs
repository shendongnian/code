    @model List<GroupVM>
    ....
    @using (Html.BeginForm())
    {
        @for(int i = 0; i < Model.Count; i++)
        {
            <div>
                <h2>@Model[i].Key</h2>
                @Html.HiddenFor(m => m[i].Key)
                @for (int j = 0; j < Model[i].Values.Count; j++)
                {
                    @Html.TextBoxFor(m => m[i].Values[j].Name)
                }
            </div>
        }
        ....
    }
