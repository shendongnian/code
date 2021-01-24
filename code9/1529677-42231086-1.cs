    var query = new RouteValueDictionary
    { 
        { "name", Model.Name },  
        { "owner", Model.Owner }
    };
    for (var i = 0; i < Model.County.Count; i++)
    {
        query["county[" + i + "]"] = Model.County[i];
    }
    @Html.PagedListPager(
        Model.SearchList, 
        Page => Url.Action("Index", "FacilityFinder", new RouteValueDictionary(query) { { "Page", Page } }),
        PagedListRenderOptions.PageNumbersOnly
    )
