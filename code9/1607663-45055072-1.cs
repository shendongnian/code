    @model List<DotnetTutorial.Data.ViewModel.CategoryViewModel>
    
    @foreach (var item in Model)
    {
        if (item.CategoryPostCount > 0)
        {
            <div class="categoryLi">
                @Html.RouteLink(item.CategoryName, "ArticlesCategoryList", new { categorySlug = @item.CategorySlug }, new { @class = "btn btn-default" })
            </div>
        }
    }
