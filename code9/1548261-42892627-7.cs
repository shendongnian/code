    class FamilyApprovedHandler : IHandle<FamilyApprovedEvent>
    {
        private readonly IDefaultMessageRepository _defaultMessageRepository;
        private readonly IEmailSender _emailSender;
        private readonly IEmailProvider _emailProvider;
        // ctor
        
        public Task Handle(FamilyApprovedEvent event)
        {
            var defaultMessage = _defaultMessageRepository.GetDefaultMessage(MessageTypes.FamilyApproved);
            var email = _emailProvider.Generate(event.Family, defaultMessage.Subject, defaultMessage.Message);
            _emailSender.Send(email);
        }
    }
