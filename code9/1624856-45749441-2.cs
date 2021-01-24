    @model CarVM
    ....
    @using (Html.BeginForm())
    {
        ..... // elements for editing ID and Description properties of CarVM
        @for (int i = ; i < Model.Gears.Count; i++)
        {
            <div>
                @Html.HiddenFor(m => m.Gears[i].ID)
                @Html.HiddenFor(m => m.Gears[i].Name) // include if your want to get this in the POST method as well
                @Html.CheckboxFor(m => m.Gears[i].IsSelected)
                @Html.LabelFor(m => m.Gears.IsSelected, Model.Gears[i].Name)
            </div>
        }
        <input type="submit" .... />
    }
