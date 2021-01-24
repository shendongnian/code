    @{
    if (product.InFrontPages.Contains(c => c.ParentCategory.Id == item.ParentCategory.Id))
        {
            <span class="glyphicon glyphicon-checked"></span>
        }
        else
        {
            <span class="glyphicon glyphicon-unchecked"></span>
        }
    }
