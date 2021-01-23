    public class Authorize
    {
        public Authorize() { }
        public AuthPolicy AuthorizeHandler(TokenAuthorizerContext request, ILambdaContext context)
        {
            var token = request.AuthorizationToken;
            
            switch (token.ToLower())
            {
                case "allow":
                    return generatePolicy("user", "Allow", request.MethodArn);
            }
     
            return null;
        }
        private AuthPolicy generatePolicy(string principalId, string effect, string resource)
        {
            AuthPolicy authResponse = new AuthPolicy();
            authResponse.policyDocument = new PolicyDocument();
            authResponse.policyDocument.Version = "2012-10-17";// default version
            authResponse.policyDocument.Statement = new Statement[1];
            Statement statementOne = new Statement();
            statementOne.Action = "execute-api:Invoke"; // default action
            statementOne.Effect = effect;
            statementOne.Resource = resource;
            authResponse.policyDocument.Statement[0] = statementOne;
            return authResponse;
        }
    }
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
