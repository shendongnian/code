    mockWebApiBusinessObject
        .Setup(m => m.UpdateWorkflowInstanceState(It.IsAny<Guid>(), It.IsAny<WorkflowElementInstance>(), It.IsAny<List<NotificationMessage>>()))
        .Callback<Guid, WorkflowElementInstance, List<NotificationMessage>>(
                    (workflowInstanceId, elementDetails, resultMessages) =>
                    {
                        resultMessages.Add(new NotificationMessage("An Error Occured!", MessageSeverity.Error));
                    });
