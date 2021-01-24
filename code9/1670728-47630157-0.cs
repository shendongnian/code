    // Create a query for system environment variables only
    SelectQuery query = new SelectQuery("SELECT * FROM Win32_ConnectionShare");
    // Initialize an object searcher with this query
    ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
    // Get the resulting collection and loop through it
    foreach (ManagementObject mo in searcher.Get())
    {
        string antecedent = mo["antecedent"].ToString();
        string dependent = mo["dependent"].ToString();
        ManagementObject share = new ManagementObject(antecedent);
        ManagementObject server = new ManagementObject(dependent);
        Console.WriteLine(server["UserName"].ToString());
        Console.WriteLine(server["ComputerName"].ToString());
        Console.WriteLine(server["ShareName"].ToString());
    }
