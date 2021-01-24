    class EmailServiceDispatcher : IEmailServiceDispatcher
    {
        IMailService man; IMailService smtp;
        public EmailServiceDispatcher(IMailService man, IMailService smtp) { ... }
        public void Send(runtimeData, parameters) =>
            GetService(runtimedData).Send(parameters);
        private IMailService GetService(runtimeData) =>
            /* some condition using runtime data */ ? man : smtp;
    }
