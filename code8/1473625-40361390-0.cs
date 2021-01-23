    // Arrange
    webService = new Mock<IServerApi>();
    webService.Setup(mock => mock.GetProjectsAsync())
        .ThrowsAsync(new TaskCanceledException());
    vm = new ProjectListViewModel(webService.Object);
    // Act/Assert
    AsyncContext.Run(() => vm.RefreshCommand.Execute(null));
