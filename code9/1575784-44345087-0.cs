    [Fact]
    public void GetEmployeeTest()
    {
        EmployeeService obj = new EmployeeService();
        var result = obj.GetEmployee();
        Assert.Collection(result, item => Assert.Contains("John", item.Name),
                                  item => Assert.Contains("John", item.Name));
    }
