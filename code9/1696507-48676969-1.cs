    using System;
    using Microsoft.Azure.Documents.Client;
    
    
    public static void Run(TimerInfo myTimer, TraceWriter log)
    {
        private static DocumentClient client;
    
        static string endpoint = "https://jaygong.documents.azure.com:443/";
        static string key = "5kbPRXD3GRhfN5v7TFTcdgoBbJfJBTELo41ZG3lXGP5gaXYcVyf2odB5EU3a8yTQ0U5QoDqpKfw8yjhbHU2glg==";
        client = new DocumentClient(new Uri(endpoint), key);
        StoredProcedureResponse<bool> sprocResponse = await client.ExecuteStoredProcedureAsync<bool>(
                                                                    "/dbs/db/colls/coll/sprocs/updatetest/");
        if (sprocResponse.Response) log.Info(sprocResponse.Response);
        log.Info($"Cosmos DB is updated at: {DateTime.Now}");
    }
