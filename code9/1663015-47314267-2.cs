    @model CourseListVm
    @using (Html.BeginForm("Index", "Courses",FormMethod.Get))
    {
        @Html.DropDownListFor(a=>a.CategoryId,Model.Categories,"All")
        <button type="submit">Filter</button>    
    }
    @foreach (var p in Model.Courses)
    {
        <p>@p.Id</p>
        <p>@p.Name</p>
    }
