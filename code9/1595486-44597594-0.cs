    public class newsalert
    {
         //Other Properties         
         [JsonProperty(PropertyName = "category")]
         IList<Category> Categories {get;set;}
    }
    
    public class Category
    {
         public string category {get;set;}
    }
