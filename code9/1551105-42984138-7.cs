    public class ActionCollection : Dictionary<ActionType, Func<IExecute>>, IActionCollection {
        public ActionCollection()
            : base() {
        }
    }
