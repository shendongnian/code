    var query = new RouteValueDictionary
    { 
        { "Page", Page }, 
        { "name", Model.Name },  
        { "owner", Model.Owner }
    };
    for (var i = 0; i < Model.County.Count; i++)
    {
        query["county[" + i + "]"] = Model.County[i];
    }
    @Html.PagedListPager(
        Model.SearchList, 
        Page => Url.Action("Index", "FacilityFinder", query),
        PagedListRenderOptions.PageNumbersOnly
    )
