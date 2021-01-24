    public void MyMethod(IOptions<ServicesSettings> services)
    {
       foreach(var service in services.Value)
           Console.WriteLine(service);
    }
