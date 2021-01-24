    public enum ExhibitState 
    { 
        Inactive = 0,
        Active = 1,
        Ready = 2,
        Complete = 3
    };
    public enum InitialStates 
    { 
        Inactive = ExhibitState.Inactive,
        Ready = ExhibitState.Ready
    };
    public void SetInitial(InitialStates state)
    {
        SetState((ExhibitState)state);
    }
