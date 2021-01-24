    using System.Collections.Generic;
    using System.Linq;
    class Program
    {
    	static void Main(string[] args)
    	{
    		var listA = new List<A>
    		{
    			new A{ Index1 =1, Index2 = 1, Index3 = 1, BarCode = "AAAAAA", Status = "Ok" },
    			new A{ Index1 =1, Index2 = 2, Index3 = 2, BarCode = "BBBBBBBBB", Status = "Not Ok" },
    			new A{ Index1 =2, Index2 = 1, Index3 = 1, BarCode = "CCCCCCC", Status = "Almost Ok" },
    		};
    
    
    		var listB = listA.Select(x => new B { BarCode = x.BarCode, Status = x.Status });
    	}
    }
    
    public class B
    {
    	public string BarCode { get; set; }
    	public string Status { get; set; }
    }
    
    public class A
    {
    	public int Index1 { get; set; }
    	public int Index2 { get; set; }
    	public int Index3 { get; set; }
    	public string BarCode { get; set; }
    	public string Status { get; set; }
    }
