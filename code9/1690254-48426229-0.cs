    [TestClass]
    public class MyServiceShould {
        [TestMethod]
        public void FindActiveCategories_WhenCalled_ShouldReturnActiveCategories() {
            //Arrange
            var moq = new Mock<IRepository<Category>>();
            var list = new List<Category> {
                new Category {Active = true},
                new Category {Active = false}
            };
            moq
                .Setup(x => x.FindByQuery(It.IsAny<Predicate<Category>>()))
                .Returns((Predicate<Category> predicate) => list.Where(x => predicate(x)));
            var service = new MyService(moq.Object);
            //Act
            var result = service.FindActiveCategories();
            //Assert
            Assert.IsTrue(result.All(x => x.Active));
        }
    }
