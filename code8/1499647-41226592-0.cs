    void Main()
    {
    	var list = new List<Data>(){
    							new Data
    							{
    							   ListId = 1,
    							   ListName = "Name1",
    							   TagId = 1,
    							   TagValue = "Tag1"
    							},
    							new Data
    							{
    							   ListId = 1,
    							   ListName = "Name1",
    							   TagId = 2,
    							   TagValue = "Tag2"
    							},
    							new Data
    							{
    							   ListId = 2,
    							   ListName = "Name2",
    							   TagId = 3,
    							   TagValue = "Tag3"
    							}};
    
    	//this is to group all SearchCategories by SearchCategoryName
    	var res = list.Select(x => new SearchCategories
    	{
    	   SearchCategoryId = x.ListId,
    	   SearchCategoryName = x.ListName
    	}).GroupBy(x => x.SearchCategoryName);
    
        //to have just distinct categories one time
    	var res2 = list.Select(x => new SearchCategories
    	{
    		SearchCategoryId = x.ListId,
    		SearchCategoryName = x.ListName
    	}).Distinct(new SearchCategoriesComparer());
    	
    	//display your data here based on a Key. The output should be Key=Name1  with two elements inside and the other one with one element Key=Name2
        res.Dump(); 
        //display your data here
    	res2.Dump(); 
    
    }
    public class Data
    {
    	public int ListId	{get; set;}
    	public string ListName { get; set; }
    	public int TagId { get; set; }
    	public string TagValue { get; set;}
    }
    
    
    public class SearchCategories
    {
    	public int SearchCategoryId { get; set; }
    
    	public string SearchCategoryName { get; set; }
    
    	public List<SearchTags> lstSubCategories = new List<SearchTags>();
    }
    
    public class SearchCategoriesComparer : IEqualityComparer<SearchCategories>
    {
    	public bool Equals(SearchCategories x, SearchCategories y)
    	{
    		return x.SearchCategoryName == y.SearchCategoryName;
    	}
    
    	public int GetHashCode(SearchCategories obj)
    	{
    		return obj.SearchCategoryName.GetHashCode();
    	}
    }
    
    
    public class SearchTags
    {
    	public string Tag{ get; set;}
    }
