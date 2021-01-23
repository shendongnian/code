    model ExcelImportAPI.Models.DataMappingViewModel
    ....
    @using (Html.BeginForm("MapData", "DataMapping", FormMethod.Post))
    {
        ....
        for (var i = 0; i < Model.XmlElements.Count; i++)
        {
            @Html.HiddenFor(m => Model.XmlElements[i].ElementName)
            @Model.XmlElements[i].ElementName
            <div>
                @Html.DropDownListFor(m => m.XmlElements[i].SelectedColumn, new SelectList(Model.ColumnList), "--Select a Value--")
            </div>
        }
        ....
    }
