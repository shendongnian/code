    public class PatientRegistrationState
    {
        private StateMachine<WorkflowState, WorkflowTrigger> stateMachine;
        private StateMachine<WorkflowState, WorkflowStateTrigger>.TriggerWithParameters<DateTime> registrationTrigger;
    
        public PatientRegistrationState(State initialState = default(State)) {
            stateMachine = new StateMachine<WorkflowState, WorkflowTrigger>(initialState);
    
            stateMachine.Configure(WorkflowState.Unregistered)
                .Permit(WorkflowTrigger.Register, WorkflowStateType.Registered);
    
            stateMachine.Configure(WorkflowState.Registered)
                .Permit(WorkflowTrigger.ScheduleSampling, WorkflowState.SamplingScheduled)
                .OnEntryFrom(registrationTrigger, PatientRegistered);
        }
    
        public WorkflowState State { get; } => stateMachine.State;
        public Action<DateTime> PatientRegistered {get; set;} = (dateOfBirth) => { };
    
        // For state changes that do not require parameters.
        public void ChangeTo(WorkflowTrigger trigger)
        {
            stateMachine.Fire<DateTime>(trigger);
        }
    
        // For state changes that require parameters.
        public void ChangeToRegistered(DateTime dateOfBirth)
        {
            stateMachine.Fire<DateTime>(registrationTrigger, dateOfBirth);        
        }
    
        // Change to other states that require parameters...
    }
    
    public class PatientRegistration
    {
        private PatientRegistrationState registrationState;
        private Patient patient;
    
        public PatientRegistration()
        {
            registrationState = PatientRegistrationState(WorkflowState.Unregistered)
            {
                PatientRegistered = RegisterPatient;
            }
        }
    
        public Patient RegisterPatient(DateTime dateOfBirth)
        {
            registrationState.ChangeToRegistered(dateOfBirth);
            logger.Info("State changed to: " + registrationState.State);
            return patient;
        }
    
        private void RegisterPatient(DateTime dateOfBirth)
        {
            // Registration code
        }
    }
