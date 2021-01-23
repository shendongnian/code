    public class TokenAuthorizerContext
    {
        public string Type { get; set; }
        public string AuthorizationToken { get; set; }
        public string MethodArn { get; set; }
    }
    
    public class AuthPolicy
    {
        public PolicyDocument policyDocument { get; set; }
        public string principalId { get; set; }
    }
    public class PolicyDocument
    {
        public string Version { get; set; }
        public Statement[] Statement { get; set; }
    }
    public class Statement
    {
        public string Action { get; set; }
        public string Effect { get; set; }
        public string Resource { get; set; }
    }
With the above classes created, the signature to my handler is:
    public async Task<AuthPolicy> FunctionHandler(TokenAuthorizerContext request, ILambdaContext context)
