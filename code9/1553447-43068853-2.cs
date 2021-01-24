    public class IdleState : sState
    {
    private readonly SoliderController controller;
    
    public IdleState(SoliderController soliderController)
    {
        controller = soliderController;
    }
    public override void Update()
    {
        
        Patrol();
        
        //Condition to change state
        if (*expresion1*)
            ToChaseState();
        if (*expresion2*)
            ToFireState();
    }
    private void Patrol()
    {
          //Your Logic for the behvaiour wanted.
    }
    public override void ToChaseState()
    {
        controller.currentState = controller.chaseState;
    }
    public override void ToFireState()
    {
        controller.currentState = controller.fireState;
    }
    public override void ToIdleState()
    {
        Debug.LogWarning("Can't transition to same state");
    }
    }
