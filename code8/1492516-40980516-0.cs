    
    // See http://nicknow.net/linqpad-dynamics-crm-sdk/ for a method to create IOrganizationService in LINQPad
    IOrganizationService conn = MyExtensions.GetCRMService("Valid CRM Connection String Goes Here");
    
    conn.Execute(new WhoAmIRequest());
    
    var times = new List<long>();
    
    for (int i = 0; i < 25; i++)
    {
    	var crmProfile = new Entity("contact");
    
    	crmProfile["emailaddress1"] = "test@demo.com.local";
    	crmProfile["firstname"] = "test";
    	crmProfile["lastname"] = $"test {i}";
    
    	var sw = new Stopwatch();
    
    	sw.Start();
    	conn.Create(crmProfile);
    	sw.Stop();
    
    	times.Add(sw.ElapsedMilliseconds);
        }
    
    Console.WriteLine($"Total Transactions: {times.Count()} / Average Time: {times.Average()} ms / Max Time: {times.Max()} ms / Min Time: {times.Min()} ms");
