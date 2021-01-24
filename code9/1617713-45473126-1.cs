    class CategorySelection
    {
        public string Category { get; set; }
    }
    var activityValue = activity.Value as Newtonsoft.Json.Linq.JObject;
    if (activityValue != null)
    {
        var categorySelection = activityValue.ToObject<CategorySelection>();
        var category = categorySelection.Category;
        //query the database for products of this category type, 
        //create another adaptive card displaying the products and send to user
    
        await context.PostAsync(reply);
    }
