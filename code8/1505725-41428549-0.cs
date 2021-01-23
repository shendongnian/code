    public class Customer
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
    }
    public void AddCustomer(Customer newCustomer)
    {
        var json = File.ReadAllText(pathToTheFile);
        var customers = JsonConvert.DeserializeObject<List<Customer>>(json);
        customers.Add(newCustomer);
        File.WriteAllText(pathToTheFile", JsonConvert.SerializeObject(customers));
    }
    public Customer GetCustomer(string id)
    {
        var json = File.ReadAllText(pathToTheFile);
        var customers = JsonConvert.DeserializeObject<List<Customer>>(json);
        var result = new Customer();
        foreach (var c in customers)
        {
            if (c.Id == id)
            {
                result = c;
                break;
            }
        }
        return result;
    }
