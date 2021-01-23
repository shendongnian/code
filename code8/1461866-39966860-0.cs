    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.WindowsAzure.StorageClient;
    using Microsoft.WindowsAzure;
    namespace ConsoleClient
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                string connectionString = "DefaultEndpointsProtocol=https;AccountName=MyAccountName;AccountKey=MyAccountKey===";
                var TablesName = GetTablesNameForAzureSubscription(connectionString);
                foreach (var r in TablesName)
                {
                    Console.WriteLine(r.ToString());
                } 
                Console.ReadKey(true);
            }
            private static List<string> GetTablesNameForAzureSubscription(string connectionString)
            {            
                CloudStorageAccount account =CloudStorageAccount
                                             .Parse(connectionString);
                CloudTableClient tableClient = new CloudTableClient 
                                           (account.TableEndpoint.ToString(),
                                           account.Credentials);
                var result = tableClient.ListTables();
                return result.ToList(); 
            } 
