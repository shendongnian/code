    [TestClass]
    public class CustomersController_Should {
        [TestMethod]
        public void GetCustomers() {
            //Arrange
            var fakeCustomers = new List<CustomerDto>{
                new CustomerDto{ Id = 1 }
            };
            var repository = new Mock<IAPICustomerRepository>();
            repository
                .Setup(_ => _.GetCustomers(It.IsAny<string>()))
                .Returns(fakeCustomers)
                .Verifiable();
            var controller = new CustomersController(repository.Object);
            //Act
            var result = controller.GetCustomers();
            //Assert
            repository.Verify();
            //..other assertions
        }
        //...Other tests
    }
