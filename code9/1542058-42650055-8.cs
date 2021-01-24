    public class Category
     public string CategoryKey{get;set;}
     public string CategoryName{get;set;}
    public ICollection<SubCategory> SubCategories {get;set;}
    
..    
     public class SubCategory
     public string SubCategoryKey{get;set;}
     public string SubCategoryName{get;set;}
