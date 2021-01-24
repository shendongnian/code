    @if (Model != null)
    {
        foreach (var item in Model)
        {
    		<li>
    			@item.Title (@item.ProductCountInfo)
    			<ul>
    				@Html.Partial("_CategoryRecursive.cshtml", new CategoryRecursiveModel
    				{
    					Children = item.Children.ToList();
    				})
    			</ul>
    		</li>
        }
    }
