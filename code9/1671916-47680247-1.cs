    var request = new QueryRequest();
    request.TableName = "YourTable";   
    request.KeyConditions = new Dictionary<string, Condition>()
    {
        { 
            "YourId",  new Condition()
            { 
                ComparisonOperator = "EQ",
                AttributeValueList = new List<AttributeValue>()
                {
                    new AttributeValue { S = YourId }
                }
            }
        }
    };
    client.QueryAsync(request,(result));
