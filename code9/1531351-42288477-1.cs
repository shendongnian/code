    @model ProductFilterVM
    ....
    <h2>@Model.Name</h2>
    ...
    <h3>Filters</h3>
    @using (Html.BeginForm("subcategory", "yourControllerName", FormMethod.Get))
    {
        foreach(var category in Model.FilterCategories)
        {
            int counter = 1; // used to generate unique keys
            <h4>@category.Name</h4>
            foreach (var selection in category.Selections)
            {
                string name = String.Format("filters[{0}-{1}]", category.ID, counter++);
                <label>
                    <input type="checkbox", name="@name" value="@selection.ID />
                    <span>@selection.Name</span>
                </label>
            }
        }
        <input type="submit" />
    }
