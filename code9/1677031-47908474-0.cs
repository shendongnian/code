    RuleFor(d => d.NotificationType).NotEmpty().WithMessage("Required");
    When(d => !string.IsNullOrEmpty(d.NotificationType) && d.NotificationType.ToUpper() == "EMAIL", () =>
    {
        RuleFor(d => d.NotificationEmail).EmailAddress().WithMessage("Invalid Email Address");
        RuleFor(d => d.NotificationEmail).NotEmpty().WithMessage("Required");
    
    });
    When(d => !string.IsNullOrEmpty(d.NotificationType) && d.NotificationType.ToUpper() == "SMS", () =>
    {
        RuleFor(d => d.NotificationContactNo).NotEmpty().WithMessage("Required");
    });
