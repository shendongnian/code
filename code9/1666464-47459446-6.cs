    static void Main(string[] args)
    {
        // find all interfaces ip adressess
        var allAdaptersIp = GetIpAddress();
        // find the default gateway
        var dg = GetDefaultGateway();
        // match the default gateway to the host address => the interface that is connected to the internet => that print host address
        Console.WriteLine("ip address that will route you to the world: " + GetInterNetworkHostIp(ref allAdaptersIp, dg, IpClass.ClassB));
        Console.ReadLine();
    }
    
    enum IpClass
    {
        ClassA,
        ClassB,
        ClassC
    }
    
    static string GetInterNetworkHostIp(ref List<IPAddress> adapters, IPAddress dg, IpClass ipclassenum)
    {
        string networkAddress = "";
        var result = "" ;
    
        switch (ipclassenum)
        {
            case IpClass.ClassA:
                networkAddress  = dg.ToString().Substring(0, dg.ToString().Length - dg.ToString().LastIndexOf(".") ); 
                break;
            case IpClass.ClassB:
                networkAddress = dg.ToString().Substring(0, dg.ToString().Length - dg.ToString().IndexOf(".",3));
                break;
            case IpClass.ClassC:
                networkAddress = dg.ToString().Substring(0, dg.ToString().Length- dg.ToString().IndexOf(".") );
                break;
            default:
    
                break;
        }
    
        foreach (IPAddress ip in adapters)
        {
            if (ip.ToString().Contains(networkAddress))
            {
                result = ip.ToString();
                break;
            }
        }
    
        if (result == "")
            result = "no ip was found";
    
        return result;
    }
