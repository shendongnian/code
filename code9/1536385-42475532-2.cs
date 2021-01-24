    [Test]
	public void InsertEmployee_Should_Add_Record() {
		//Arrange
		var employees = new List<Employee>();
		var repositoryMock = new Mock<IEmployeeRepository>();
		repositoryMock
			.Setup(_ => _.Add(It.IsAny<Employee>()))
			.Callback<Employee>(employees.Add)
			.Verifiable();
		var newEmp = new Employee("Ram", "Prem", 30, 90000007);
		newEmp.SetRepository(repositoryMock.Object);
		//Act
		newEmp.InsertEmployee();
		//Assert
		employees.Should()
			.HaveCount(1)
			.And
			.Contain(newEmp);
		repositoryMock.Verify();
	}
	[Test]
	public void GetAllEmployees_Should_GetAll() {
		//Arrange
		var expected = new List<Employee>() {
			new Employee("Ram", "Prem", 30, 90000007),
			new Employee("Pam", "Rem", 31, 90000008)
		};
		var repositoryMock = new Mock<IEmployeeRepository>();
		repositoryMock
			.Setup(_ => _.GetAll())
			.Returns(expected)
			.Verifiable();
		var newEmp = new Employee();
		newEmp.SetRepository(repositoryMock.Object);
		//Act
		var actual = newEmp.GetAllEmployees();
		//Assert
		expected.Should().Equal(actual);
		repositoryMock.Verify();
	}
	
