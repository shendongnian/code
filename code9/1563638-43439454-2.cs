    public void Get_ShouldReturnListOfInternshipsViewModel() {
        //Arrange
        var allInternshipWithFeedbackViewModels = new List<InternshipsWithFeedbackViewModel> {
            //...populate collection
        };
        var internshipViewModelFactoryMock = new Mock<IInternshipsViewModelFactory>();
        internshipViewModelFactoryMock
            .Setup(_ => _.CreateInternshipsViewModel(It.IsAny<IInternshipRepository>(), It.IsAny<IEnumerable<Internship>>()))
            .Returns(() => allInternshipWithFeedbackViewModels);
        var repositoryMock = new Mock<IInternshipRepository>();
        repositoryMock.Setup(_ => _.GetAll()).Returns(new List<Internship>());
        var _controller = new MyController(internshipViewModelFactoryMock.Object, repositoryMock.Object);
        //Act
        var okResult =
            _controller.GetInternshipsForCoordinator() as
                OkNegotiatedContentResult<IEnumerable<InternshipsWithFeedbackViewModel>>;
        //Assert
        Assert.IsNotNull(okResult);
    }
