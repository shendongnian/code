    var disableWrapper = Html.ViewContext.ViewData["DisableWrapper"] as bool?;
    if (disableWrapper.GetValueOrDefault())
    {
        foreach (var content in Model.FilteredItems)
        {
            Html.RenderContentData(content.GetContent(), false, Model.Tag);
        }
    }
    else
    {
        Html.RenderContentArea(Model);
    }
