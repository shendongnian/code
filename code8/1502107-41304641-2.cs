    IConfiguration config = new ConfigurationBuilder()
        .SetBasePath(appEnv.ApplicationBasePath)
        .AddJsonFile("settubgs.json");
        .Build();
    var settings = config.GetSection("SmtpVerificationSenderSettings")
        .Get<SmtpVerificationSenderSettings>();
    // Verify the settings object
    if (string.IsNullOrWhiteSpace(settings.MailHost)
        throw new ConfigurationErrorsException("MailSettings MailHost missing.");
    if (string.IsNullOrWhiteSpace(settings.MailHost)
        throw new ConfigurationErrorsException("MailSettings UserName missing.");
    // etc
    // Register the EmailVerificationSender class
    services.AddSingleton<IVerificationSender>(new EmailVerificationSender(settings));
