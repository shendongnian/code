    void Main()
    {
    
    	List<Object> listobj = new List<object>{
       new object[]{"A01001","sucess","on"},
       new object[]{"A01002","fail","off"}};
    	listobj.Dump();
    
    	var second = listobj.Cast<object[]>().Select(l => new RowItem { 
    														GOODS_ID=l[0].ToString(),
    														AUDIT_STATUS=l[1].ToString(),
    														APPLY_STATUS=l[2].ToString() 
    	                                            });
    	second.Dump();
    }
    
    public class RowItem
    {
    	public string GOODS_ID { get; set; }
    	public string AUDIT_STATUS { get; set; }
    	public string APPLY_STATUS { get; set; }
    }
