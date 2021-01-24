        public APIGatewayProxyResponse FunctionHandler(APIGatewayProxyRequest request, ILambdaContext context)
        {
            var bodyString = request?.Body;
            if (!string.IsNullOrEmpty(bodyString))
            {
                dynamic body = JsonConvert.DeserializeObject(bodyString);
                if (body.input != null)
                {
                    body.input = body.input?.ToString().ToUpper();
                    return new APIGatewayProxyResponse
                    {
                        StatusCode = 200,
                        Body = JsonConvert.SerializeObject(body)
                    };
                }
            }
            return new APIGatewayProxyResponse
            {
                StatusCode = 200
            };
        }
