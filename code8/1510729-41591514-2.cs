    public static class FieldExtensions
    {
        public static string SearchSection<T>(this T page, bool overriding) where T : PageData
        {
            // we need to check if this page is a CategoryPage first
    		if(page is CategoryPage) {
    			return ""; // I assume nothing?
    		}
    
    		var ancestors = loader.GetAncestors(page.ContentLink).OfType<CategoryPage>();
    		if(ancestors.any()){
    			var closestCategoryPage = ancestors.First();
    			return closestCategoryPage.whateverproperty;
    		}
    
    		// customs: nothing to declare
    		return "";
        }
    }
