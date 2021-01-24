    [Theory]
    [AutoMoqData]
    public async Task Should_Add_Schedule(StudentSchedule model)  
       //Arrange
        var expectedId = 0;
        var expectedDate = DateTime.Now;
        
        var context = new Mock<IStudenScheduleService>();
        context.Setup(_ => _.SaveChangesAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(1)
            .Callback(() => {
                model.EnrolmentRecordID = ++expectedId;
                model.DateCreated = expectedDate;
            })
            .Verifiable();
        context.Setup(_ => _.AddAsync(It.IsAny<StudentSchedule>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((StudentSchedule m, CancellationToken t) => m)
            .Verifiable();
        var _command = new CommandSchedule(context.Object);
        model.AcademicYearID = "16/17";
        model.DateCreated = null;
        //Act
        await _command.Add(model);
        //Assert
        context.Verify();
        Assert.AreEqual(expectedId, model.EnrolmentRecordID);
        Assert.AreEqual(expectedDate, model.DateCreated);
    }
