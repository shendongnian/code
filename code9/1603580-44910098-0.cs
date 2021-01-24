    public class CategoryModel
    {
	    public long iDCategory { get; set; }
        public string nom { get; set; }
	    public List<CategoryModel> ChildCategories {get;set;}
	    public List<DocumentModel> ChildDocuments {get;set;}
    }
