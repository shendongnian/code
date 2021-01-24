    using Microsoft.Azure.Documents;
    using Microsoft.Azure.Documents.Client;
    using System;
    
    namespace ConsoleApp1
    {
        class Program
        {
            private static DocumentClient client;
    
            static void Main(string[] args)
            {
                
                client = new DocumentClient(new Uri("***"), "***");
    
                var docUri = UriFactory.CreateDocumentUri("db", "collpart", "1");
                var reqOptions = new RequestOptions { PartitionKey = new PartitionKey("1") };
                client.DeleteDocumentAsync(docUri, reqOptions).Wait();
    
                //block
                Console.ReadLine();
            }
        }
    }
