    Employee employee = Mock.Of<Employee>();
    employee.IsPrimaryContact = true;
    List<Employee> employees = new List<Employee>();
    employees.Add(employee);
    Customer customer = Mock.Of<Customer>();
    customer.Employees = employees;
    var mockCustomerRepository = new Mock<ICustomerRepository>();
    mockCustomerRepository.Setup(p => p.GetById(It.IsAny<Guid>())).Returns(customer);
    Repository.Customer = mockCustomerRepository.Object;
