    public enum ExhibitState { Ready, Active, Complete, Inactive };
    public enum InitialStates { Ready, Inactive };
    public void SetInitial(InitialStates state)
    {
        SetState((ExhibitState)state);
    }
