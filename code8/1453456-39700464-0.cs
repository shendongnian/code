    var exchange = new ExchangeService(ExchangeVersion.Exchange2010_SP2);
    exchange.Credentials = new WebCredentials("username", "password", "domain");
    exchange.AutodiscoverUrl("user@domain.com");
    
    // see #1
    // exchange.ImpersonatedUserId = new ImpersonatedUserId(ConnectingIdType.SmtpAddress, ImpersonatedUser@domain.com");
    
    var task = new Task(exchange);
    task.Subject = "foo";
    task.Body = new MessageBody("bar");
    task.Status = TaskStatus.InProgress;
    task.StartDate = PurchaseOrder.OrderDate;
    task.DueDate = PurchaseOrder.DeliverDate;
    task.Save();
    
    // see #2
    // task.Save(new FolderId(WellKnownFolderName.Tasks, "delegatedUser@domain.com"));
