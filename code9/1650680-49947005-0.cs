    var message = "message";
    var defaultTenantAdmin = new UserIdentifier(1, 2);
    var hostAdmin = new UserIdentifier(null, 1);
    await _notificationPublisher.PublishAsync(
        "App.SimpleMessage",
        new MessageNotificationData(message),
        severity: NotificationSeverity.Info,
        userIds: new[] { defaultTenantAdmin, hostAdmin }
    );
