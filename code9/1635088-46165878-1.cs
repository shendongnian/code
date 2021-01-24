    @model ManageViewModel
    ...
    @using (Html.BeginForm("Manage", "ControllerName", FormMethod.Get))
    {
        @Html.CheckBoxFor(m => m.OldInventoryIsShown)
        @Html.LabelFor(m => m.OldInventoryIsShown)
        ... // any other search/filter properties
        <input type="submit" value="search" />
    }
    <table id="bookInventory" class="table table-hover">
        ....
    </table>
    <p>Page @(modelList.PageCount < modelList.PageNumber ? 0 : modelList.PageNumber) of @modelList.PageCount</p>
    @Html.PagedListPager(modelList, page => 
        Url.Action("Manage", new { page = page, oldInventoryIsShown = Model.OldInventoryIsShown })) // plus any other search/filter properties
