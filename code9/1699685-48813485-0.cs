    public abstract class Policy : IPolicy
    {
        protected readonly IPolicy _innerPolicy1;
        protected readonly IPolicy _innerPolicy2;
    
       public Task Evaluate(Input input)
        {
            _innerPolicy1.Evaluate(input);
            if (HasInnerPolicy2Permission(input))
            {
                _innerPolicy2.Evaluate(input);
            }
    
            return Task.FromResult(input);
        }
    
        protected abstract bool HasInnerPolicy2Permission(Input input);
    }
    
    public class Policy1 : Policy
    {
        protected override bool HasInnerPolicy2Permission(Input input)
        {
            return true;
        }
    }
    
    public class Policy2 : Policy
    {
        private readonly IPermissionService _permissionService;
        protected override bool HasInnerPolicy2Permission(Input input)
        {
            return _permissionService.GetInnerPolicy2Permission(input);
        }
    }
	
