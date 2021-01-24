    using Microsoft.Azure.Documents;
    using Microsoft.Azure.Documents.Client;
    using System;
    using System.Linq;
    
    namespace ConsoleApp2
    {
        class Program
        {
    
            private static DocumentClient client;
    
            static string endpoint = "***";
            static string key = "***";
            static string database = "***";
            static string collection = "***";
            static void Main(string[] args)
            {
                
                client = new DocumentClient(new Uri(endpoint), key);
    
                try
                {
                    Sample querysample = client.CreateDocumentQuery<Sample>(
                    UriFactory.CreateDocumentCollectionUri(database, collection))
                    .Where(so => so.id == "1")
                    .AsEnumerable()
                    .First();
    
                    Console.WriteLine(querysample.tablename);
    
                    querysample.tablename = "Table2";
    
                    RequestOptions options = new RequestOptions();
                    options.PartitionKey = new PartitionKey("1");
                    options.ConsistencyLevel = ConsistencyLevel.Session;
                    var result =  client.ReplaceDocumentAsync(UriFactory.CreateDocumentUri(database, collection, "1"), querysample, options).Result;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
    
    
                Console.ReadLine();
            }
        }
    
        public class Sample
        {
            public string id { get; set; }
            public string tablename { get; set; }
        }
    }
