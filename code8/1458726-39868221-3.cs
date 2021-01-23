    [TestMethod]
    public void Delete_Journal() {
        // Arrange
        
        //Configure mapping just for this test but something like this
        //should be in accessible from your composition root and called here.
        var config = new MapperConfiguration(cfg => {
            cfg.CreateMap<Journal, JournalViewModel>();
            cfg.CreateMap<JournalViewModel, Journal>();
        });
        
        var mapper = config.CreateMapper(); // IMapper
        // Simulate PDF file
        var mockFile = Mock.Create<HttpPostedFileBase>();
        Mock.Arrange(() => mockFile.FileName).Returns("Test.pdf");
        Mock.Arrange(() => mockFile.ContentLength).Returns(255);
        // Create view model to send.
        var journalViewModel = new JournalViewModel();
        journalViewModel.Id = 1;
        journalViewModel.Title = "Test";
        journalViewModel.Description = "TestDesc";
        journalViewModel.FileName = "TestFilename.pdf";
        journalViewModel.UserId = 1;
        journalViewModel.File = mockFile; // Add simulated file
        var status = new OperationStatus {
            Status = true
        };
        Mock.Arrange(() => journalRepository.DeleteJournal(Arg.IsAny<Journal>())).Returns(status);
        var controller = new PublisherController(journalRepository, membershipRepository, mapper);
        // Act        
        var result = controller.Delete(journalViewModel) as RedirectToRouteResult;
        // Assert
        Assert.AreEqual(result.RouteValues["Action"], "Index");
    }
