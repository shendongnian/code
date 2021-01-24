    Amazon.Athena.AmazonAthenaClient _client = new Amazon.Athena.AmazonAthenaClient(AwsAccessKeyId, AwsSecretAccessKey, EndPoint);
                    Amazon.Athena.Model.ResultConfiguration resultConfig = new Amazon.Athena.Model.ResultConfiguration();
                    resultConfig.OutputLocation = "s3://"+BucketName+"/key1/";                
                    string query = "SELECT * FROM copalanadev.logs";
                    //Populate the request object
                    Amazon.Athena.Model.StartQueryExecutionRequest queryExec = new Amazon.Athena.Model.StartQueryExecutionRequest();
                    queryExec.QueryString = query;
                    //queryExec.QueryExecutionContext = queryExecutionContext;
                    queryExec.ResultConfiguration = resultConfig;
                StartQueryExecutionResponse athenaResponse = _client.StartQueryExecution(queryExec);//throws exception
