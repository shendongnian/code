    @for (int i = 0; i < Model.SubModels.Count; i++)
    {
       // postback everything
        @Html.HiddenFor(m => m.SubModels[i].MySubModelId)
        @Html.HiddenFor(m => m.SubModels[i].Description)
    }
