    public class ActionFactoryResolver
    {
        private readonly ActionFactoriesConfiguration _configuration;
    
        public ActionFactoryResolver(ActionFactoriesConfiguration configuration)
        {
            _configuration = configuration;
        }
    
        public IActionFactory CreateFactory(ActionType actionType)
        {
            var factoryType = _configuration.GetActionFactoryType(actionType);
            if (factoryType != null)
                return Activator.CreateInstance(actionType);
    
            return null;
        }
    }
