    AmazonDynamoDBClient amazonDynamoDbClient= new AmazonDynamoDBClient()
    var filterExpression = "#aws_s3_bucket = :v_aws_s3_bucket and contains(#aws_s3_key,:v_aws_s3_key)";
    var projectExpression = "#aws_s3_key,filename,#region,aws_s3_bucket,#projecttype,folder,#siteid,locationname,createdon,modifiedon";
    ScanRequest request = new ScanRequest
            {
                TableName = "Test1",
                FilterExpression = filterExpression,
                ExpressionAttributeNames = new Dictionary<string, string>
                            {
                              { "#region", "region" },
                              { "#siteid", "siteid" },
                              { "#projecttype", "projecttype" },
                              { "#aws_s3_key", "aws_s3_key" },
                              { "#aws_s3_bucket", "aws_s3_bucket" }                       
                            },
                ExpressionAttributeValues = new Dictionary<string, AttributeValue> {
                            {":v_aws_s3_bucket", new AttributeValue { S =  "sampleBucket"}},
                            {":v_aws_s3_key", new AttributeValue { S =  "92226"}}
                            },
                ConsistentRead = true,
                ProjectionExpression = projectExpression
            };
        do
        {   
            response = amazonDynamoDbClient.Scan(request); 
            request.ExclusiveStartKey = response.LastEvaluatedKey;
        } while (response.lastEvaluatedKey.Count != 0);
