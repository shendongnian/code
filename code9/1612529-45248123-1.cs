    @for(int i = 0; i < Model.MyDogs.Count; i++)
    {
        @Html.HiddenFor(m => m.MyDogs[i].ID)
        @Html.CheckBoxFor(m => m.MyDogs[i].IsSelected)
        @Html.LabelFor(m => m.MyDogs[i].IsSelected, Model.Dogs[i].Name)
    }
    @Html.HiddenFor(m => m.MyProduct.ID)
    @Html.TextBoxFor(m => m.MyProduct.Name)
