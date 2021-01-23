    public enum States
    {
        Idle,
        CreatingShape
    }
    public enum Triggers
    {
        CreateShape,
        CancelCurrentAction
    }
    public class AppStateMachine : ObservableObject
    {
        public StateMachine<States, Triggers> _stateMachine = new StateMachine<States, Triggers>(States.Idle);
        public AppStateMachine()
        {
            _stateMachine.Configure(States.Idle)
                .Permit(Triggers.CreateShape, States.CreatingJunction)
                .Ignore(Triggers.CancelCurrentAction);
            _stateMachine.Configure(States.CreatingShape)
                .Permit(Triggers.CancelCurrentAction, States.Idle)
                .Ignore(Triggers.CreateShape);
        }
