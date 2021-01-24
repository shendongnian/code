    [TestMethod]
    public void _KissWithReceiverNotInLove() {
        // Arange.
        var p1 = new Person { Id = 5, Name = "M. Love" };
        var p2 = new Person { Id = 17, Name = "Paul Atreid" };
        var relations = new List<Relation>()
        {
            new Relation{ GiverId = p1.Id, ReceiverId = p2.Id }
            //The above should satisfy the first expected predicate.
            //Note there are no other relations in this list.
            //That is by design to make the second predicate return false.
        };
        var kissRepositoryMock = new Mock<IRelationRepository>();
        kissRepositoryMock
            .Setup(m => m.Loves(It.IsAny<Expression<Func<Relation, bool>>>()))
            .Returns((Expression<Func<Relation, bool>> predicate) => relations.Any(predicate.Compile()));
        var kissManager = new KissManager(kissRepositoryMock.Object);
        // Act.
        var result = kissManager.Kiss(p1, p2);
        // Assert.
        Assert.IsFalse(result);
    }
