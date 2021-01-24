    public class Customer
	{
	    public string Name { get; }
	    private List<Order> orders = new List<Order>();
	    public List<Order> historicOrders = new List<Order>();
	    public Customer(string name)
	    {
	        Name = name;
	    }
	    public void AddOrder(string name, string date)
	    {
	        if (name == "" || date == "" ) ;
	        else if (DateTime.Parse(date) > DateTime.Now) ; 
	        else
	        {
	            for (int i = 0; i < orders.Count; i++)
	            {
	                if (orders[i].OrderName == name)
	                {
	                    orders.RemoveAt(i);
	                }
	            }
	            orders.Add(new Order(name, date));
	            historicOrders.Add(new Order(name, date));
	        }
	    }
	    public void Print()
	    {
	        Console.WriteLine(Name);
	        Console.Write("Orders: ");
	        orders.ForEach(Console.Write);
	        Console.WriteLine();
	        Console.WriteLine($"Order Count: {orders.Count}");
	        Console.WriteLine();
	        Console.WriteLine();
	    }
	    public override string ToString()
	    {
	        return $"{Name}";
	    }
	}
