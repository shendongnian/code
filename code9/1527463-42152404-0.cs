            Microsoft.VisualBasic.Devices.ComputerInfo computerInfo = new Microsoft.VisualBasic.Devices.ComputerInfo();
            Console.WriteLine(Environment.ProcessorCount);
            Console.WriteLine(computerInfo.AvailablePhysicalMemory);
            Console.WriteLine(computerInfo.AvailableVirtualMemory);
            Console.WriteLine(computerInfo.OSFullName);
            Console.WriteLine(computerInfo.OSPlatform);
            Console.WriteLine(computerInfo.OSVersion);
            Console.WriteLine(computerInfo.TotalPhysicalMemory);
            Console.WriteLine(computerInfo.TotalVirtualMemory);
