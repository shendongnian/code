    public class Property
    {
        public string Name { get; private set; }
        private IPropertyRules _rules;
        private List<User> _occupants = new List<User>();
        private IEventLog _eventLog;
        public Property(IPropertyRules rules, IEventLog eventLog)
        {
            _rules = rules;
            _eventLog = eventLog;
        }
        public ActionResult Do(IAction action, User user)
        {
            _eventLog.Add(action, user);
            if (_rules.UserAllowedTo(action, user, this))
            {
                switch (action)
                {
                    case Open o:
                        Open();
                        return new ActionResult(true, $"{user} opened {Name}");
                    case Enter e:
                        Enter(user);
                        return new ActionResult(true, $"{user} entered {Name}");
                }
                return new ActionResult(false, $"{Name} does not know how to {action} for {user}");
            }
            return new ActionResult(false, $"{user} is not allowed to {action} {Name}");
        }
        private void Enter(User user)
        {
            _occupants.Add(user);
        }
        private void Open()
        {
            IsOpen = true;
        }
        public bool IsOpen { get; set; }
    }
    public interface IEventLog
    {
        void Add(IAction action, User user);
    }
    public class Enter : IAction
    {
    }
    public interface IPropertyRules
    {
        bool UserAllowedTo(IAction action, User user, Property property);
    }
    public class Open : IAction
    {
        
    }
    public class ActionResult
    {
        public ActionResult(bool successful, string why)
        {
            Successful = successful;
            WhatHappened = why;
        }
        public bool Successful { get; private set; }
        public string WhatHappened { get; private set; }
    }
    public interface IAction
    {
    }
    public class User
    {
    }
