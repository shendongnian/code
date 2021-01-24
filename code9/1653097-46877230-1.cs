    using Moq;
    using Xunit;
    namespace MockAbstractClass
    {
        public class EmployeeTests
        {
            [Fact]
            public void IsAdultMock()
            {
                var employeeMock = new Mock<Employee>() { CallBase = false };
                employeeMock.Setup(x => x.IsAdult()).Returns(true);
                var employee = employeeMock.Object;
                var result = employee.IsAdult();
                Assert.True(result);
            }
        }
    }
