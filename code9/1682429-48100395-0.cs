    Task<AppleModel> task = new Task<AppleModel>(() => appleModel);
    
    var taskWorker = TaskWorkerFactory.Create(taskModel);
    
    dynamic taskWorkerWrapper = Mock.NonPublic.Wrap((AppleTaskWorker)taskWorker);
    Mock.NonPublic
        .Arrange<Task<AppleModel>>(taskWorkerWrapper.GetAppleModel( ArgExpr.IsAny<Guid>())).Returns(task);
    
    taskWorker.Start();
    //Some Assertion
