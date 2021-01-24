    using System;
    using System.Threading.Tasks;
    
    public static void Run(string myQueueItem, Stream inputBlob, TraceWriter log)
    {
        log.Info($"C# storage queue trigger function processed message: {myQueueItem}");
        StreamReader reader = new StreamReader(inputBlob);
        string text = reader.ReadToEnd();
        log.Info(text);
    }
