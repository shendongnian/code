    using System;
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Uri test = GetCrmUrl("00000", "orgid", "server");
                Console.WriteLine(test);
                Console.ReadKey();
            }
            public static Uri GetCrmUrl(string phone, string organisationid, string server)
            {
                string clienturl = @"https://petsolutions.crm8.dynamics.com/nga/engagementhub.aspx?org=" + organisationid + "&server=" + server;
                Uri x = new Uri(clienturl, UriKind.Absolute);
                return x;
            }
        }
    }
