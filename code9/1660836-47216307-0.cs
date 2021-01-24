    class Customer
    {
    	public int ID { get; set; }
    	public string Name { get; set; }
    }
    
    List<Customer> ls = new List<Customer>();
    ls.Add(new Customer() { ID = 1, Name = "Name 1" });
    ls.Add(new Customer() { ID = 2, Name = "Name 2" });
    
    PropertyInfo info = ls[0].GetType().GetProperty("ID");
