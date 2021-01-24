       public class Invoker
        {
            Dictionary<string, Action> _actions = new Dictionary<string, Action>();
        
            public void Do(string action)
            {
                if (_actions.ContainsKey(action)) _actions[action]();
                else
                {
                    // no match 
                }
            }
        
            public void AddAction(string action, Action f)
            {
                _actions.Add(action, f);
            }
    }
