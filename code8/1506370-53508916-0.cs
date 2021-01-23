    using Amazon.Lambda.APIGatewayEvents;
    using Amazon.Lambda.Core;
    public class Function
    {
        public APIGatewayCustomAuthorizerResponse FunctionHandler(APIGatewayCustomAuthorizerRequest input, ILambdaContext context)
        {
            bool ok = false;
            // authorization logic here...
            if(input.AuthorizationToken == "up-down-left-right-a-b-select-start")
            {
                ok = true;
            }
            return new APIGatewayCustomAuthorizerResponse
            {
                PrincipalID = "***",//principal info here...
                UsageIdentifierKey = "***",//usage identifier here (optional)
                PolicyDocument = new APIGatewayCustomAuthorizerPolicy
                {
                    Version = "2012-10-17",
                    Statement = new List<APIGatewayCustomAuthorizerPolicy.IAMPolicyStatement>() {
                          new APIGatewayCustomAuthorizerPolicy.IAMPolicyStatement
                          {
                               Action = new HashSet<string>(){"execute-api:Invoke"},
                               Effect = ok ? "Allow" : "Deny",
                               Resource = new HashSet<string>(){  "***" } // resource arn here
                          }
                    },
                }
            };
        }
    }
