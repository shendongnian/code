        [TestMethod]
        public void Sample()
        {
            //arrange
            var mockEntityTest = new Mock<DbSet<EntityTest>>();
    
            var unitOfWork = new  Mock<IUnitOfWork>();
            var valcalContext = new Mock<ValcalContext>();
    
            valcalContext.Setup(vc => vc.Set<EntityTest>()).Returns(mockEntityTest.Object);
            var mock = valcalContext.Object;
    
            unitOfWork.Setup(uow => uow.Context).Returns(mock);
    
            var repository = new RepositoryTest(unitOfWork.Object);
    
            //act
            var entityTests = repository.All;
            //assert
            Assert.AreEqual(entityTests.ToList().Count,0);
        }
