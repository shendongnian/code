    using System;
    using Microsoft.Azure.Documents.Client;
    
    
    public static void Run(TimerInfo myTimer, TraceWriter log)
    {
        private static DocumentClient client;
    
        static string endpoint = "https://***.documents.azure.com:443/";
        static string key = "***";
        client = new DocumentClient(new Uri(endpoint), key);
        StoredProcedureResponse<bool> sprocResponse = await client.ExecuteStoredProcedureAsync<bool>(
                                                                    "/dbs/db/colls/coll/sprocs/updatetest/");
        if (sprocResponse.Response) log.Info(sprocResponse.Response);
        log.Info($"Cosmos DB is updated at: {DateTime.Now}");
    }
