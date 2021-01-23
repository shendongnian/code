                    HttpRequestMessage httpRequestPost =
                        AwsSigningHelper.GenerateAwsSignedPostRequest(someapigatewayurl,
    //                        AwsSigningHelper.EmptyContent,
    //                        new StringContent("{ \"test\" : \"test\" }", Encoding.UTF8, "application/json"),
                            new StringContent("text!", Encoding.UTF8, "text/plain"),
                            EnvironmentVariables.Region, EnvironmentVariables.AccessKeyId, EnvironmentVariables.SecretAccessKey,
                            EnvironmentVariables.SessionToken);
    
                    var responsePost = httpClient.SendAsync(httpRequestPost).Result;
                    
