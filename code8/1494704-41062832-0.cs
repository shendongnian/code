    ....
    public async Task GetEmployees()
        {
            var loginService = new LoginService();
            EmployeeList = await loginService.GetEmployeesAsync();
        }
    ....
