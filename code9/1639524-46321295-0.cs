    public static void TransferMoney()
    {
        Console.Clear();
        Console.WriteLine("--- Transfer Money ---");
        Console.Write("Please enter your account's ID: ");
        string id = Console.ReadLine();
        Console.Write("Please enter the Name of the person you would like to tranfer funds to: ");
        string name = Console.ReadLine();
        Console.Write("Enter the amount of funds you would like to transfer: ");
        string amount = Console.ReadLine();
        foreach (Customer c in Bank.AllCustomers)
        {
               if (c.Id() == id)
               {  
                   c.setMoney(c.getMoney()-amount)
               }
        } 
        foreach (Customer c in Bank.AllCustomers)
        {
               if (c.getName() == name)
               {  
                   c.setMoney(c.getMoney()+amount)
               }
         }
        ShowAllCustomers();
        }
    }
