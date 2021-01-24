    custDictionary.Add(aCustomer.Status.ToUpper(), aCustomer);
    string status = Console.ReadLine().ToUpper();
    if (custDictionary.ContainsKey(status))
    {
        //// code
    }
