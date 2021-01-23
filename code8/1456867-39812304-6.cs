    @model List<ReviewVM>
    @Html.BeginForm())
    {
        for (int i = 0; i < Model.Count; i++)
        {
            @Html.HiddenFor(m => m[i].ID)
            @Html.CheckBoxFor(m => m[i].IsSelected)
            @Html.DisplayFor(m => m[i].Title)
        }
        <input type="submit" .... />
    }
