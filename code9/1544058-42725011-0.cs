    static void Main(string[] args)
    {
        Choice ch=new Choice();
        IData idata = ch.Fetch(true);
        Console.WriteLine("Enter ID and Name:");
        idata.ID = int.Parse(Console.ReadLine());
        idata.Name = Console.ReadLine();
        var employee = idata as Employee;
        if (employee != null)
        {
            employee.getDetails();
        }
        //Console.WriteLine("Id={0} & Name={1}", idata.ID, idata.Name);
        Console.WriteLine(idata.GetType());
        Console.ReadLine();
    }
