    class Action
    {
        public Condition Parent { get; }
        public Action(Condition parent)
        {
            Parent = parent;
            parent.Actions.Add(this); // not sure if its a good idea
        }
    }
