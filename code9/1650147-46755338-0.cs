     [TestMethod()]
        public void Create_return_journal()
        {
            var journalNew = Mock.Create<JournalViewModel>();
            var journal = Mock.Create<Journal>();
            Mock.Arrange(() => mapper.Map<JournalViewModel, Journal>(journalNew)).Returns(journal);
            var userMock = Mock.Create<MembershipUser>();
            Mock.Arrange(() => userMock.ProviderUserKey).Returns(1);
            Mock.Arrange(() => membershipService.GetUser()).Returns(userMock);
            var opStatusMock = Mock.Create<OperationStatus>();
            opStatusMock.Status = true;
            Mock.Arrange(() => journalService.AddJournal(journal)).Returns(opStatusMock);
            //Act
            PublisherController controller = new PublisherController(journalService, membershipService, mapper);
            RedirectToRouteResult actionResult = (RedirectToRouteResult)controller.Create(journalNew);
            //Assert
            Assert.IsNotNull(actionResult);
        }
