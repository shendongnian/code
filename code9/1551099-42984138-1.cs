    public class Executor {
        readonly IActionCollection factories;
        public Executor(IActionCollection factories) {
            this.factories = factories;
        }
        public bool ExecuteAction(ActionRequest request) {
            if (factories.ContainsKey(request.ActionType))
                return factories[request.ActionType]().Execute(request);
            return false;
        }
    }
