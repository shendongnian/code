    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;    
    using System.Management;
    
    namespace testereeee
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("hello World");
                GetProcessorName()
    
                Console.ReadKey();
            }
    
            private static string GetProcessorName()
            {
                string ProcessorName = "";
                ManagementObjectSearcher mos
                = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Processor");
    
                foreach (ManagementObject mo in mos.Get())
                    ProcessorName = mo["Name"].ToString();
                Console.WriteLine(ProcessorName.ToString());
                return ProcessorName;
            }        
        }
    }
