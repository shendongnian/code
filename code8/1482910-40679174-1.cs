    using System;
    using System.Management.Automation;
    using System.Net;
    using System.Security;
    namespace Sample
    {
        class Program
        {
            static void Main(string[] args)
            {
                PowerShell ps = PowerShell.Create();
                ps.AddScript("Get-Content C:\\machineslist.txt");
                ps.AddCommand("Restart-Computer");
                SecureString secureString = new NetworkCredential("", "Password").SecurePassword;
                PSCredential psc = new PSCredential("Administrator", secureString);
                ps.AddParameter("Credential", psc);
                ps.AddParameter("Force");
                // Simulation only
                ps.AddParameter("WhatIf");
                var results = ps.Invoke();
                foreach (var error in ps.Streams.Error)
                {
                    Console.WriteLine(error);
                }
                foreach (PSObject result in results)
                {
                    Console.WriteLine(result);
                    //Console.WriteLine("{0,-24}{1}", result.Members["Length"].Value, result.Members["Name"].Value);
                }
            }
        }
    }
