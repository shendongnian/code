    public enum MoveState
    {
        None,
        Jump,
        Stop,
        Slither
    }
    private MoveState CheckMoveState(MoveState myMoveState)
    {
        if (myMoveState == MoveState.Slither || myMoveState == MoveState.Stop)
            return myMoveState;
        return MoveState.None;
    }
    private MoveState _currentMoveState = MoveState.None;
    public MoveState CurrentMoveState
    {
        get { return _currentMoveState; }
        set { _currentMoveState = CheckMoveState(value); }
    }
