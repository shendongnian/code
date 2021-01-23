    public class TicketValidator : AbstractValidator<Ticket>
    {
        public TicketValidator Policy()
        {
            RuleFor(ticket => ticket.Policy.PolicyNumber)
             .NotEmpty()
             .WithMessage("Policy Number is missing.");
    
            return this;
        }
    
        public TicketValidator ApplSignedState()
        {
            RuleFor(ticket => ticket.Policy.ApplSignedInState)
             .NotEmpty()
             .WithMessage("Application Signed In State is missing or invalid.");
    
            return this;
        }
    
        public TicketValidator DistributionChannel()
        {
            RuleFor(ticket => ticket.Policy.DistributionChannel)
            .NotEmpty()
            .WithMessage("Distribution Channel is missing.");
    
            return this;
        }
    
        public static TicketValidator Validate()
        {
            return new TicketValidator();
        }
    }
