    public class ActionExecutor
    {
        // ommit details
        public void Execute(IEnumerable<IAction> actions)
        {
            foreach (var action in actions)
            {
                action.Do();
            }
        }
    }
