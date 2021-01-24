    // in your Program.cs, create instances of your worker class like this:
    List<Worker> workers = new List<Worker>();
    
    for (int i = 0; i < MAX_LIST_VALUE; i++)
    {
        Console.WriteLine("Enter name for employee:");
        string name = Console.ReadLine();
    
        Console.WriteLine("Enter hours per week:");
        decimal hours = Decimal.Parse(Console.ReadLine());
    
        Console.WriteLine("Enter hourly wage:");
        decimal wage = Decimal.Parse(Console.ReadLine());
    
        // this creates an instance of your worker class and adds it to the list
        workers.Add(new Worker(name, hours, wage));
    }
    
    // now you have a list of workers that you can sort using Linq or some other method:
    var sortedWorkers = workers.OrderByDescending(w => w.GetWeeklyPay());
    
    // and you can output them in order from most pay to least:
    foreach (Worker w in sortedWorkers)
    {
        Console.WriteLine("Worker " + w.Name + " makes " + w.GetWeeklyPay().ToString() + " dollars per week!");
    }
