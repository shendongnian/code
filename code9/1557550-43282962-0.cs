    public class MySaga :
      MassTransitStateMachine<MySagaState>
    {
        public MySaga()
        {
            InstanceState(x => x.State, Executing, Completed, Failed);
            // 1 = Initial, 2 = Final, 3 = Executing, 4 = Completed
            // 5 - Failed (1 & 2 are built-in states)
        }
        public State Executing { get; private set; }
        public State Completed { get; private set; }
        public State Failed { get; private set; }
        ...
    }
