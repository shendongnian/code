    using System;
    using System.Text;
    using System.Threading;
    using System.Management;
    using System.Security;
    using Microsoft.Management.Infrastructure;
    using Microsoft.Management.Infrastructure.Options;
    namespace WMITest
    {
    class Program
    {
        static void Main(string[] args)
        {
            string computer;
            string domain = "";
            string username = "Administrator";
            string password;
            Console.WriteLine("Enter PC IP Address:");
            computer = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Enter Password:");
            password = Console.ReadLine();
            Console.Clear();
            try
            {
                ConnectionOptions connection = new ConnectionOptions();
                connection.Username = username;
                connection.Password = password;
                connection.Authority = "ntlmdomain:" + domain;
                ManagementScope scope = new ManagementScope(
                    "\\\\" + computer + "\\root\\cimv2", connection);
                scope.Connect();
                ObjectQuery query = new ObjectQuery(
                    "SELECT * FROM Win32_Service WHERE Name like 'MSSQL$%'");
                ManagementObjectSearcher searcher =
                    new ManagementObjectSearcher(scope, query);
                foreach (ManagementObject queryObj in searcher.Get())
                {
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("Win32_Service instance");
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("Name: {0}", queryObj["Name"]);
                }
                Console.ReadLine();
            }
            catch (ManagementException err)
            {
                Console.WriteLine("An error occurred while querying for WMI data: " + err.Message);
            }
            catch (System.UnauthorizedAccessException unauthorizedErr)
            {
                Console.WriteLine("Connection error (user name or password might be incorrect): " + unauthorizedErr.Message);
            }
        }
        
    }
    }
