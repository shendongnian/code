       public int Code {get;set;}
       public List<SubCategory> SubCategories {get;set;}
    }
    
    public class SubCategory
    {
       public int SubCode {get;set;}
       public int ParentCode {get;set;}
       public Category ParentCategory {get;set;}
    }
