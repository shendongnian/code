     var connectionString = "<Azure event hub capture storage account connection string>";
     var containerName = "<Azure event hub capture container name>";
     var blobName = "<Azure event hub capture BLOB name (ends in .avro)>";
    
     var storageAccount = CloudStorageAccount.Parse(connectionString);
     var blobClient = storageAccount.CreateCloudBlobClient();
     var container = blobClient.GetContainerReference(containerName);
     var blob = container.GetBlockBlobReference(blobName);
     using (var stream = blob.OpenRead())
     using (var reader = AvroContainer.CreateGenericReader(stream))
         while (reader.MoveNext())
             foreach (dynamic result in reader.Current.Objects)
             {
                 var record = new AvroEventData(result);
                 record.Dump();
             }
     
     public struct AvroEventData
     {
         public AvroEventData(dynamic record)
         {
             SequenceNumber = (long) record.SequenceNumber;
             Offset = (string) record.Offset;
             DateTime.TryParse((string) record.EnqueuedTimeUtc, out var enqueuedTimeUtc);
             EnqueuedTimeUtc = enqueuedTimeUtc;
             SystemProperties = (Dictionary<string, object>) record.SystemProperties;
             Properties = (Dictionary<string, object>) record.Properties;
             Body = (byte[]) record.Body;
         }
         public long SequenceNumber { get; set; }
         public string Offset { get; set; }
         public DateTime EnqueuedTimeUtc { get; set; }
         public Dictionary<string, object> SystemProperties { get; set; }
         public Dictionary<string, object> Properties { get; set; }
         public byte[] Body { get; set; }
     }
