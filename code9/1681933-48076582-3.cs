     @{
        // assign the IHtmlString created by the HTML Helper to a variable
        var grid = Html.Grid(stuff).Columns(columns =>
            {
              //stuff
            }).Sortable().Filterable().WithMultipleFilters()
            .WithPaging(WebSettings.DefaultPageSize)
            .WithAjax(true).Exportable(true));
     }
    
    @* now render the variable content *@
    @grid
