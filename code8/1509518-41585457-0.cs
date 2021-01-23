            AmazonDynamoDBClient client = new AmazonDynamoDBClient();
            var context = new DynamoDBContext(client);
            
            Table bookmaster = Table.LoadTable(client, "bookmaster");
            context1.Logger.LogLine("In method : Function Handler : start");            
            string result = PutDataAsync(bookmaster, context1).Result;
            context1.Logger.LogLine("Result = " + result);            
        }
        private static async Task<string> PutDataAsync(Table table , ILambdaContext context1)
        {
            try
            {
                string sampleBookId = "3";
                var doc = new Document();
                doc["strid"] = sampleBookId;
                Document x = await table.PutItemAsync(doc);
                context1.Logger.LogLine("In method after put item async");
                return "success";
            }
            catch(Exception ex)
            {
                context1.Logger.LogLine("In method after put item async catch block");
                return "failed";
            }                     
        }
