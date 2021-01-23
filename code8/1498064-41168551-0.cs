    static void CustomerInfo()
    {
        Console.WriteLine("Custom First Name: ");
        string firstName = Console.ReadLine();
        Console.WriteLine("Customer Last Name: ");
        string lastName = Console.ReadLine();
        Console.WriteLine("Customer Address: ");
        string address = Console.ReadLine();
        PrintCustomerDetails(firstName, lastName, address);
    }
