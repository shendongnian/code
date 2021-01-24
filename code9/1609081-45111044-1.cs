    mockWebApiBusinessObject
        .Setup(m => m.UpdateWorkflowInstanceState(workflowInstanceGuid, workflowElementInstance, It.IsAny<IList<NotificationMessage>>()))
        .Callback<Guid, WorkflowElementInstance, IList<NotificationMessage>>(
                    (workflowInstanceId, elementDetails, resultMessages) =>
                    {
                        resultMessages.Add(new NotificationMessage("An Error Occured!", MessageSeverity.Error));
                    });
