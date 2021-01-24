    public class NationalWorkflow : BaseWorkflow
    {
        public NationalWorkflow(SwiftRequest request) : this(request, Objects.RBDb)
        { }
        public NationalWorkflow(SwiftRequest request, RBDbContext dbContext)
        {
            this.request = request;
            this.dbContext = dbContext;
            this.ConfigureWorkflow();
        }
        protected override void ConfigureWorkflow()
        {
            workflow = new StateMachine<SwiftRequestStatus, SwiftRequestTriggers>(
               () => request.SwiftRequestStatus, state => request.SwiftRequestStatus = state);
            workflow.OnTransitioned(Transitioned);
            workflow.Configure(SwiftRequestStatus.New)
                .OnEntry(NotifyRequestCreation)
                .Permit(SwiftRequestTriggers.ProcessRequest, SwiftRequestStatus.InProgress);
            workflow.Configure(SwiftRequestStatus.InProgress)
                .OnEntry(ValidateRequestEligibility)
                .Permit(SwiftRequestTriggers.AutoApprove, SwiftRequestStatus.Approved)
                .Permit(SwiftRequestTriggers.AdvancedServicesReview, SwiftRequestStatus.PendingAdvancedServices);
    .....................
    }
