	public interface IAuthorizationRule<TRequest>
	{
		Task Evaluate(TRequest message);
	}
	public class AuthorizationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
	{
		private readonly IAuthorizationRule<TRequest>[] _rules;
		public AuthorizationBehavior(IAuthorizationRule<TRequest>[] rules)
		{
			_rules = rules;
		}
		public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next)
	    {
	    	// catch it or let it bubble up depending on your strategy
	    	await Task.WaitAll(_rules.Select(x => x.Evaluate(request)));
	        
	        return next();
	    }
	}
