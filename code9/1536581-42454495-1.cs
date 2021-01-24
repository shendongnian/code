    public class Action
    {
    }
    public class ActionAdventure : Action
    {
    }
    public class Base
    {
        private readonly List<Action> _actions = new List<Action>();
        public List<Action> Actions
        {
            get { return _actions; }
        }
        // call this from your code
        protected virtual void HandleActions()
        {
            foreach (var action in Actions)
            {
            }
        }
    }
    public class Derived : Base
    {
        protected override void HandleActions()
        {
            var adventures = Actions.OfType<ActionAdventure>();
            foreach (var adventure in adventures)
            {
            }
        }
    }
