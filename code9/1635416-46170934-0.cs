    [FunctionName("Blob")]
    public static void Blob(
        [BlobTrigger("mystorage/data/{yyyy}/{MM}/{dd}/app.csv")] Stream message, 
        string yyyy,
        string MM,
        string dd,
        TraceWriter log)
    {
        log.Info($"Found {yyyy}-{MM}-{dd}");
    }
