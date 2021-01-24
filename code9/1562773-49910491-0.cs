    using System; 
    using Amazon.Lambda.Core;
    using Amazon.Lambda.Serialization.Json;
    using Amazon.Lambda.APIGatewayEvents;
    
    [assembly:LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]
    
    namespace AwsDotnetCsharp { 
        public class Handler { 
            public APIGatewayProxyResponse Hello(APIGatewayProxyRequest request) { 
                return new APIGatewayProxyResponse() {
                    StatusCode = 200, 
                    Body = "Go Serverless v1.0! Your function executed successfully!", 
                }; 
            }    
        } 
    }
