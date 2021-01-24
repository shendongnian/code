    public class Executor {
        readonly IActionCollection factories;
        public Executor(IActionCollection factories) {
            this.factories = factories;
        }
        public bool ExecuteAction(ActionRequest request) {
            if (factories.ContainsKey(request.ActionType)) {
                var action = factories[request.ActionType]();
                return action.Execute(request);
            }
            return false;
        }
    }
