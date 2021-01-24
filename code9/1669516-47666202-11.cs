    public EmailDecorator(IDbConnectionFactory connectionFactory,
                          ILogger log,
                          IHttpContextAccessor httpContextAccessor,
                          IEmailClient emailClient) : base(connectionFactory, log)
    {
        _emailClient = emailClient;
        _httpContextAccessor = httpContextAccessor;
    }
