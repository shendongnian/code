    private void configureStateMachine(WorkflowState state)
    {
        ...
        stateMachine.Configure(WorkflowState.Registered)
            .Permit(WorkflowTrigger.ScheduleSampling, WorkflowState.SamplingScheduled)
            .OnEntryFrom(registrationTrigger, (dateOfBirth) => OnRegistered(dateOfBirth));
    }
    
    private void OnRegistered(DateTime dateOfBirth)
    {
        //Registration code
    }
    
    public void RegisterPatient(DateTime dateOfBirth)
    {
        stateMachine.Fire(WorkflowTrigger.Register, dateOfBirth);
    }
