    class B
    {
    	public string BarCode {get;set;}
    	public string Status {get;set;}
    }
    
    List<B> listB = listA.Select(x=> new B{ BarCode = x.BarCode, Status = x.Status });
