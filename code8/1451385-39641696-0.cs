    if (requestMSI1 == RequestState.Absent && requestMSI2 == RequestState.Absent)
    {
        this.WisState = State.FullUninstalling;
        Bootstrapper.Engine.Plan(LaunchAction.Uninstall);
    }
    else
    {
        this.WisState = State.Uninstalling;
        Bootstrapper.Engine.Plan(LaunchAction.Repair);
    }
