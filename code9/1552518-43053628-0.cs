    // using Amazon.DynamoDBv2;
    // using Amazon.DynamoDBv2.Model;
    
    var client = new AmazonDynamoDBClient();
    var request = new GetItemRequest
    {
      TableName = "YourTableName",
      ProjectionExpression = "Id, Attribute1, Attribute2",
      Key = new Dictionary<string, AttributeValue>
      {
        { "Id", new AttributeValue { N = "some_value_for_id" } }
      },
    };
    var response = client.GetItem(request);
