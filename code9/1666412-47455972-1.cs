                do
                {
                    var request = new QueryRequest
                    {
                        TableName = "oauth_users",
                        KeyConditionExpression = "user_id = :user_id",
                        ExpressionAttributeValues = new Dictionary<string, AttributeValue> {{":user_id", new AttributeValue { S =  userid_str }}},
                        IndexName = "useridindex",
                        // Optional parameters.
                        Limit = 1,
                        ExclusiveStartKey = lastKeyEvaluated
                    };
                    var response = client.Query(request);
                    // Process the query result.
                    foreach (Dictionary<string, AttributeValue> item in response.Items)
                    {
                    }
                    lastKeyEvaluated = response.LastEvaluatedKey;
                } while (lastKeyEvaluated != null && lastKeyEvaluated.Count != 0);
