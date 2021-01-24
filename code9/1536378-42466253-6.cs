    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    
    namespace UnitTestProject1
    {
        [TestClass]
        public class EmployeeRepositoryTests
        {
            [TestMethod]
            public void Insert()
            {
                // Arrange
                var repositoryMock = new Mock<IEmployeeRepository>();
                var employees = new List<Employee>
                {
                    new Employee("John", "Smith", 20, 12345678),
                    new Employee("Robert", "Taylor", 20, 12345678)
                };
    
                // We simulate the DB returns the previous employees when calling the "GetAll()" method 
                repositoryMock.Setup(x => x.GetAll()).Returns(employees);
    
                // Act
                var result = repositoryMock.Object.GetAll();
    
                // Assert
                CollectionAssert.AreEquivalent(employees, result);
            }
        }
    }
