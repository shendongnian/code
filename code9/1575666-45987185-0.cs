    class Program
    {
        static void Main(string[] args)
        {
            var script = "Get-NetIPAddress ";
            var powerShell = PowerShell.Create().AddScript(script).Invoke();
            foreach (var thing in powerShell)
            {
                try
                {
                    //the Members must be PROPERTIES of the PowerShell object
                    var name = (thing.Members["InterfaceAlias"].Value);
                    var ip= (thing.Members["IPv4Address"].Value);
                    Console.WriteLine("Connection: " + name + " .......... IP: " + ip);
                }
                catch
                {
                }
                
            }
            
            Console.Read();
        }
    }
