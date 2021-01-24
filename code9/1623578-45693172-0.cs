    mockedFacade.Setup(facade => facade.RequestPayment()).Callback(
        () =>
        {
            CallbackMessageService.AddMessage(new CallbackMessage{Type = 2, Value = 1, MessageID = Guid.NewGuid().ToString()});
        }).Verifiable();
    mockedFacade.Setup(facade => facade.GetCallbackMessage()).Returns(CallbackMessageService.GetNextMessage());
    mockedFacade.Setup(facade => facade.CallbackMessageProcessed(It.IsAny<CallbackMessage>())).Callback(
        (CallbackMessage c) =>
        {
            CallbackMessageService.MessageResolved(c);
            mockedFacade.Setup(facade => facade.GetCallbackMessage()).Returns(CallbackMessageService.GetNextMessage());
        });
