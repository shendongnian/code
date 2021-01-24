    [TestMethod]
    public void KissWithReceiverNotInLove()
    {
        // Arange.
        var p1 = new Person { Id = 5, Name = "M. Love" };
        var p2 = new Person { Id = 17, Name = "Paul Atreid" };
    
        var kissRepositoryMock = new Mock<IRelationRepository>();
        kissRepositoryMock
            .SetupSequence(m => m.Loves(It.IsAny<Expression<Func<Relation, bool>>>()))
            .Returns(true)
            .Returns(false);
    
        var kissManager = new KissManager(kissRepositoryMock.Object);
    
        // Act.
        var result = kissManager.Kiss(p1, p2);
    
        // Assert.
        Assert.IsFalse(result);
    }
