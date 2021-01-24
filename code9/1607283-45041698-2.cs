    container.Register<IMailServiceDispatcher, MailServiceDispatcher>();
    container.RegisterConditional<IMailService, MandrillEmailService>(WithParamName("man"));
    container.RegisterConditional<IMailService, SmtpEmailService>(WithParamName("smtp"));
    // Helper method
    private static Predicate<PredicateContext> WithParamName(string name) =>
        c => c.Consumer.Target.Name == name;
