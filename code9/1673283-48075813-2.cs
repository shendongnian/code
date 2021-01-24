    class Program
        {
            static void Main() {
                Console.WriteLine("----------------Update Employee -------------------");
                Console.WriteLine("Enter id which you want to update");
                string id = Console.ReadLine();
                var response=DemoData(id).Result;
                Console.WriteLine("the data from webapi: "+response);
                var host = new JobHost();
               // The following code ensures that the WebJob will be running continuously
                host.RunAndBlock();
            }
            public static async Task<string> DemoData(string id)
            {
                HttpClient client = new HttpClient();        
                string path = "http://localhost:53581/api/values/" + id;
                Console.WriteLine("Enter the file name.");
                string fileName = Console.ReadLine();
                string filepath = "E:\\JanleyZhang\\" + fileName;
                var filepathJson = JsonConvert.SerializeObject(filepath);// convert other FileStream type to json string
                var data = new StringContent(content: filepathJson,
                 encoding: Encoding.UTF8,
                 mediaType: "application/json");
                var response = await client.PutAsync(path, data);//get response from web api
                var content = response.Content;
                var result = await content.ReadAsStringAsync();//read content from response
    
    
                //upload the data to a queue
                string connectionString = AmbientConnectionStringProvider.Instance.GetConnectionString(ConnectionStringNames.Storage);
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);
    
                CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
                CloudQueue queue = queueClient.GetQueueReference("myqueue2");
                queue.CreateIfNotExists();
    
                AudioSampleEntityModel model = new AudioSampleEntityModel()
                {
                    id=id,
                    SampleBlob=result //pass  the result to this property
                };
                queue.AddMessage(new CloudQueueMessage(JsonConvert.SerializeObject(model))); //store the file content to queue
                return result;
            }
    }
