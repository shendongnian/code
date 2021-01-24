        public Document Add <T>(T entity, IAmazonDynamoDB dbClient)
                {
                    Amazon.DynamoDBv2.DataModel.DynamoDBContext db = new Amazon.DynamoDBv2.DataModel.DynamoDBContext(dbClient);                                   
                    Document document = db.ToDocument(entity);
                    return document;
                }
