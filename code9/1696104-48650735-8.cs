    public class AuthorizationAlwaysFails : IAuthorizationPolicy
    {
        public ClaimSet Issuer => throw new NotImplementedException();
        public string Id => Guid.NewGuid().ToString();
        
        public bool Evaluate(EvaluationContext evaluationContext, ref object state)
        {
            var sf = new SecurityFault();
            sf.Operation = "Evaluate";
            sf.ProblemType = "Authorization failed";
            throw new FaultException<SecurityFault>(sf);
        }
    }
