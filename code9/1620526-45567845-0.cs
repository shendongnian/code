    public static HttpResponseMessage Run(
      [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequestMessage req,
      [DocumentDB(
            "logDatabase",
            "logCollection",
            ConnectionStringSetting = "cflogdev_DOCUMENTDB",
            //PartitionKey = "user",
            CreateIfNotExists = true
        )] out object logDocument,
      ILogger log)
