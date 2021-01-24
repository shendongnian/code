    public void SomeMethod()
    {
         var newEmployee = new Employee() 
         {
              Name = textboxName.Text,
              Pay = double.Parse(textboxPay.Text)
         }
         
         EmployeeController.Instance.Employees.Add(newEmployee);
    
         labelEmployeePay.Text = newEmployee.Pay;
         labelTotalPay.Text = EmployeeController.Instance.TotalPay;
    }
