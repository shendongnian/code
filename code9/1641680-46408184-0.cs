    @for (var i = 0; i < Model.InspectedFields.Count; i++)
    {
        @Html.HiddenFor(m => m.InspectedFields[i].Key)
        for (var j = 0; j < Model.InspectedFields[i].Value.Count; j++)
        {
            @Html.HiddenFor(m => m.InspectedFields[i].Value[j].Key)
            @Html.EditorFor(m => m.InspectedFields[i].Value[j].Value.Page)
        }
    }
