    [TestMethod]
    public void Delete_Id() {
        // Arrange
        var expected = new Journal {
            Id = 1,
            Description = "TestDesc",
            FileName = "TestFilename.pdf",
            Title = "Tester",
            UserId = 1,
            ModifiedDate = DateTime.Now
        };
        Mock.Arrange(() => journalRepository.GetJournalById(1)).Returns(expected);
        var controller = new PublisherController(journalRepository, membershipRepository);
        // Act
        var result = controller.Delete(1) as ViewResult;
        var model = result.Model as JournalViewModel;
        // Assert
        Assert.AreEqual(expected, model);
    }
