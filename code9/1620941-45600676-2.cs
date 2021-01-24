    public static MainCategories WhereNameStartsWith(this MainCategories jsonBody, string str)
    {
        MainCategories result = new MainCategories();
        //if you want to keep the result json structure `as is` return a MainCategories object
        
        foreach (var subCategory in jsonBody.SelectMany(mainCategory => mainCategory.Value).Where(subCategory => subCategory.Name.StartsWith(str)))
        {
            if(result.ContainsKey(subCategory.Parent))
                result[subCategory.Parent].Add(subCategory);
            else
                result.Add(subCategory.Parent, new List<SubCategory> {subCategory});
        }
        // if you just want the subcategories matching the condition create a WhereListNameStartsWith method
        // where `result` is a list of subcategories matching the condition
        return  result;
    }    
