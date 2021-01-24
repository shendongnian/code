    public class ActionFactoriesConfiguration
    {
        private readonly Dictionary<ActionType, Type> _configuration;
    
        public ActionFactoriesConfiguration()
        {
            _configuration =  new Dictionary<ActionType, Type>
            {
                { ActionType.Rename, RenameActionFactory }
            }
        }
    
        public Type GetActionFactoryType(ActionType actionType)
        {
            if (_configuration.ContainsKey(actionType))
            {
                return _configuration[actionType];
            }
            return null;
        }
    }
