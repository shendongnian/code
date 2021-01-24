    var mock = new Mock<IWebApiBusinessObject>();
                mock.
                Setup(m => m.UpdateWorkflowInstanceState(It.IsNotNull<Guid>(), It.IsNotNull<WorkflowElementInstance>(),It.IsAny<List<NotificationMessage>>() )).
                Callback(() => 
                    {
                        messages.Add(new NotificationMessage("error msg", MessageSeverity.Severe));
                        messages.Add(new NotificationMessage("Ignore Message", MessageSeverity.Normal)); // this is optional... u can remove it if u want.
                    });
