     public abstract class Stock
     {	
	   public int ID{get;set;}
	   public string stockName{get;set;}
     }
     [Table("dbname.scheme.Stock", Schema = "dbo")]
     public class WinterStock : Stock
     {
	   public WinterStock() : base() { }
     }
     [Table("dbname.scheme.Stock", Schema = "dbo")]
     public class SummerStock : Stock
     {
	  public SummerStock() : base() { }
     }
