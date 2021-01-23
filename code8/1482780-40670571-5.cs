    [TestClass]
    public class TestToyModel {
        [TestMethod]
        public void TestToyCreate() {
            //Arrange
            var toys = new List<Toy>();
            toys.Add(new Toy{ Id = "1234", Name = "Toy1" });
    
            var dbToys = GetQueryableMockDbSet(toys); //DbSet<Toy>
    
            var contextMock = new Mock<IContext>();
            contextMock.Setup(x => x.Toys).Returns(dbToys);
    
            var sut = new MyClass(contextMock.Object);
    
            //Act
            sut.Add(new ToyModel{ Id = "5678", Name = "Toy2" });
    
            //Assert
            var expected = 2;
            var actual = toys.Count;
            Assert.AreEqual(expected, actual);
        }
    
        //...other code removed for brevity
    }
