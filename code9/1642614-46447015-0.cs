    string FullComputerName = "<Name of Remote Computer>";
                ConnectionOptions options = new ConnectionOptions();
                ManagementScope scope = new ManagementScope("\\\\" + FullComputerName + "\\root\\cimv2", options);
                scope.Connect();
                ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_TerminalService");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
                ManagementObjectCollection queryCollection = searcher.Get();
                foreach (ManagementObject queryObj in queryCollection)
                {
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("Win32_TerminalService instance");
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("Started: {0}", queryObj["Started"]);
                    Console.WriteLine("State: {0}", queryObj["State"]);
                    Console.WriteLine("Status: {0}", queryObj["Status"]);
                }
