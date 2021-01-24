        void Main()
       {
    	
    	var tables4a = new List<Table4>(){new Table4{id=1, price=40}, new Table4{id=2, price=41}};
    	var tables4b = new List<Table4>(){new Table4{id=1, price=50}, new Table4{id=2, price=51}};
    	var tables3 = new List<Table3>(){new Table3{id=1, price=20, tables4= tables4a}, new Table3{id=2, price=21, tables4 = tables4b}};
    	var tables2 = new List<Table2>() {new Table2(){id=1, price=5, tables3= tables3, table1= new Table1(){
    	id = 1, price = 11
    	}}};
    	
    	
    	var Total123 = tables2.Where(x=>x.id ==1)
    	.SelectMany(x=>x.tables3, (table2,b)=>new{
    	table2
    	})
    	.SelectMany(x=>x.table2.tables3, (table_2,table_3)=>new{
    	table_2,
    	table_3
    	})
    	.Select(v=> new {
    	SumTable1= v.table_2.table2.table1.price,
    	SumTable2= v.table_2.table2.price,
    	SumTable3 =v.table_2.table2.tables3.Sum(x=>x.price),
    	SumTable4= v.table_3.tables4.Sum(x=>x.price),
    		})
    		.Distinct()
    	;
    				
    	Total123.Dump();
    }
    
    
    public class Table1
    {
    	public int id {get;set;}
    	public int price {get; set;}
    }
    
    public class Table2
    {
    	public int id {get;set;}
    	public int price {get; set;}
    	public Table1 table1 {get; set;}
    	public List<Table3> tables3 {get; set;}
    }
    
    public class Table3
    {
    	public int id {get;set;}
    	public int price {get; set;}
    	public List<Table4> tables4 {get; set;}
    }
    
    public class Table4
    {
    	public int id {get;set;}
    	public int price {get; set;}
    }
