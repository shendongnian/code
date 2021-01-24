    using System.Collections.Generic;
    using NUnit.Framework;
    using Moq;
    
    namespace UnitTestProject1
    {
        [TestFixture]
        public class EmployeeRepositoryTests
        {
            [Test]
            public void GetAll()
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
