    static void Main(string[] args)
    {
       Dictionary<string, Customer> custDictionary = new Dictionary<string, Customer>(); //Dictionary declared
    
       List<Customer> lst = new List<Customer>(); //List of objects declared
    
       Customer aCustomer = new Customer(); //Customer object created
    
       /**Assign values - Starts**/
       aCustomer.CustomerId = 1001;
       aCustomer.CustomerName = "John";
       aCustomer.Address = "On Earth";
       aCustomer.Status = "Active";
       if (!custDictionary.ContainsKey(aCustomer.CustomerId))
			custDictionary.Add(aCustomer.CustomerId, aCustomer);
		else
			custDictionary[aCustomer.CustomerId] = aCustomer;
       aCustomer.CustomerId = 1002;
       aCustomer.CustomerName = "James";
       aCustomer.Address = "On Earth";
       aCustomer.Status = "Inactive";
       /**Assign values - Ends**/
	   
       if (!custDictionary.ContainsKey(aCustomer.CustomerId))
			custDictionary.Add(aCustomer.CustomerId, aCustomer);
		else
			custDictionary[aCustomer.CustomerId] = aCustomer;
       
    
       string status = Console.ReadLine().ToUpper();
    
       if (custDictionary.ContainsKey(aCustomer.CustomerId)) //If key found in the dictionary
       {
          Customer cust = custDictionary[aCustomer.CustomerId];
          Console.WriteLine(cust.CustomerId + " " + cust.CustomerName); //Outputs the final result - Right now no result found here
       }
    
      Console.ReadKey();
    }
   
