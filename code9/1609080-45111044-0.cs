    mockWebApiBusinessObject
        .Setup(m => m.UpdateWorkflowInstanceState(workflowInstanceGuid, workflowElementInstance, It.IsAny<List<NotificationMessage>>()))
        .Callback<Guid, WorkflowElementInstance, List<NotificationMessage>>(
                    (workflowInstanceId, elementDetails, resultMessages) =>
                    {
                        resultMessages.Add(new NotificationMessage("An Error Occured!", MessageSeverity.Error));
                    });
