    #r "Microsoft.Azure.Documents.Client"
    using Microsoft.Azure.Documents;
    using Microsoft.Azure.Documents.Client;
    using System.Net;
    private static string endpointUrl = "https://blahblah.documents.azure.com:443/"; // ** Copied from 'URI' in Read-Write Keys screen.
    private static string authorizationKey = "blahblahblah"; // ** Copied from 'PRIMARY KEY' in Read-Write Keys screen.
    private static DocumentClient client = new DocumentClient(new Uri(endpointUrl), authorizationKey, new ConnectionPolicy() {
    	RequestTimeout = new TimeSpan(0, 0, 30),
    	RetryOptions = new RetryOptions() {
    		MaxRetryAttemptsOnThrottledRequests = 3,
    		MaxRetryWaitTimeInSeconds = 60
    	}
    });
    public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log)
    {
	    bool success = true;
        try {
    		await client.DeleteDocumentAsync("dbs/p3wOAA==/colls/p3wOAPsBIwA=/docs/p3wOAPsBIwAEAAAAAAAAAA==/");
    		// or you could use the UriFactory if you have the document id
    		//Uri documentUri = UriFactory.CreateDocumentUri("name of database","name of collection","document id");
    		//await client.DeleteDocumentAsync(documentUri);
    	}
    	catch(Exception ex){
    		success = false;
            log.Info("ex: " + ex.StackTrace);
	    }
	    
        return success
            ? req.CreateResponse(HttpStatusCode.OK, "Deletion succeeded")
            : req.CreateResponse(HttpStatusCode.BadRequest, "Deletion failed");
    }
