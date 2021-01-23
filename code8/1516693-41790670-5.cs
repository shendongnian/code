    var now = DateTime.Parse("2017-01-22");
    var _dateTimeNowProvider = new Mock<IDateTimeNowProvider>();
    var controller = new ProductController(_ProductRepository.Object, 
                            _WebService.Object, _dateTimeNowProvider.Object );
    _dateTimeNowProvider.Setup(x => x.Now).Returns(now);
    _WebService.Setup(b => b.Add(1,now)).Returns("0");
