    public static void Main()
	{
		List<Operation> list = new List<Operation>();
		
		Operation o1 = new Operation();
		o1.ID = 1;
		o1.CRUD = "Insert";
		list.Add(o1);
		
		Operation o2 = new Operation();
		o2.ID = 2;
		o2.CRUD = "Insert";
		list.Add(o2);
		
		Operation o3 = new Operation();
		o3.ID = 3;
		o3.CRUD = "Insert";
		list.Add(o3);
		
		Operation o4 = new Operation();
		o4.ID = 2;
		o4.CRUD = "Remove";
		list.Add(o4);
		
		Operation o5 = new Operation();
		o5.ID = 4;
		o5.CRUD = "Insert";
		list.Add(o5);
		
		Operation o6 = new Operation(){ID=2, CRUD = "Insert"};
		list.Add(o6);
		
		Operation o7= new Operation(){ID=3, CRUD = "Remove"};
		list.Add(o7);
		
		Operation o8= new Operation(){ID=5, CRUD = "Insert"};
		list.Add(o8);
		
		Operation o9= new Operation(){ID=3, CRUD = "Insert"};
		list.Add(o9);
		
		Operation o10= new Operation(){ID=5, CRUD = "Remove"};
		list.Add(o10);
		
		var result = list.GroupBy(x => x.ID).ToDictionary(x => x.Key, x => x.Last().CRUD);
		
		foreach(var item in result)
		{
			Console.WriteLine(item.Key + ": " + item.Value);
		}
		
		list = list.GroupBy(x => x.ID)
			.Select(x=> new Operation { ID = x.Key, CRUD = x.Last().CRUD }).ToList();
		
		Console.WriteLine("List values");
		
		foreach(var item in list)
		{
			Console.WriteLine(item.ID + ": " + item.CRUD);
		}
        
        //output for 5 is Remove.
	}
	
	public class Operation
	{
		public int ID { get; set; }
		public string CRUD { get; set; }
	}
 
