    Dictionary<string, Customer> custDictionary = new Dictionary<string, Customer>(StringComparer.InvariantCultureIgnoreCase); //Dictionary declared
    
       List<Customer> lst = new List<Customer>(); //List of objects declared
    
       Customer aCustomer = new Customer(); //Customer object created
    
       /**Assign values - Starts**/
       aCustomer.CustomerId = 1001;
       aCustomer.CustomerName = "John";
       aCustomer.Address = "On Earth";
       aCustomer.Status = "Active";
       custDictionary.Add(aCustomer.Status, aCustomer); //Added to the dictionary with key and value
       
       Customer bCustomer = new Customer(); //Customer object created
       bCustomer.CustomerId = 1002;
       bCustomer.CustomerName = "James";
       bCustomer.Address = "On Earth";
       bCustomer.Status = "Inactive";
    
    
       custDictionary.Add(bCustomer.Status, bCustomer); //Added to the dictionary with key and value
    
       string status = Console.ReadLine().ToUpper();
    
       if (custDictionary.ContainsKey(status)) //If key found in the dictionary
       {
          Customer cust = custDictionary[status];
          Console.WriteLine(cust.CustomerId + " " + cust.CustomerName); //Outputs the final result - Right now no result found here
       }
    
      Console.ReadLine();
