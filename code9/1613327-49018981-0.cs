        public class AddCorsApiGatewayDocumentFilter : IDocumentFilter
        {
            private Operation BuildCorsOptionOperation()
            {
                var response = new Response
                {
                    Description = "Successful operation",
                    Headers = new Dictionary<string, Header>
                    {
                        { "Access-Control-Allow-Origin", new Header(){Type="string",Description="URI that may access the resource" } },
                        { "Access-Control-Allow-Methods", new Header(){Type="string",Description="Method or methods allowed when accessing the resource" } },
                        { "Access-Control-Allow-Headers", new Header(){Type="string",Description="Used in response to a preflight request to indicate which HTTP headers can be used when making the request." } },
                    }
                };
                return new Operation
                {
                    Consumes = new List<string> { "application/json" },
                    Produces = new List<string> { "application/json" },
                    Responses = new Dictionary<string, Response>{{"200",response}}
                };
            }
            private object BuildApiGatewayIntegrationExtension()
            {
                return new
                {
                    responses = new
                    {
                        @default = new
                        {
                            statusCode = "200",
                            responseParameters = new Dictionary<string, string>
                                {
                                    { "method.response.header.Access-Control-Allow-Methods", "'POST,GET,OPTIONS'" },
                                    { "method.response.header.Access-Control-Allow-Headers", "'Content-Type,X-Amz-Date,Authorization,X-Api-Key'"},
                                    { "method.response.header.Access-Control-Allow-Origin", "'*'"}
                                }
                        },
                    },
                    passthroughBehavior = "when_no_match",
                    requestTemplates = new Dictionary<string, string> { { "application/json", "{\"statusCode\": 200}" } },
                    type = "mock"
                };
            }
            public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context)
            {
                foreach (var path in swaggerDoc.Paths)
                {
                    var corsOptionOperation = BuildCorsOptionOperation();
                    var awsApiGatewayExtension = BuildApiGatewayIntegrationExtension();
                    corsOptionOperation.Extensions.Add("x-amazon-apigateway-integration", awsApiGatewayExtension);
                    path.Value.Options = corsOptionOperation;
                }
            }
        }
