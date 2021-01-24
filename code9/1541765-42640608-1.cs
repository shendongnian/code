    public static class HtmlExtensions 
    {
    	public static MvcHtmlString LocalDropDownListFor<TModel, TProperty>(
    		this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expr, 
    		IEnumerable<SimpleItem> items)
    	{
    		return helper.DropDownListFor(expr, 
    			items.Select(x => new SelectListItem { Text = x.Text, Value = x.Value } ));
    	}
    }
