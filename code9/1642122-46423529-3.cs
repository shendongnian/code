    string status = Console.ReadLine().ToUpper();
    if (custDictionary.ContainsKey(status)) //If key found in the dictionary
    {
        Customer cust = custDictionary[status];
        Console.WriteLine(cust.CustomerId + " " + cust.CustomerName); //Outputs the final result - Right now no result found here
    }
    Console.ReadKey();
