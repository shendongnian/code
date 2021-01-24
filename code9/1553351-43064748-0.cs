    public static void SetSalaryDetails(EmployeeInfo employeeInfo, SalaryDetails salaryDetails, string prefix)
    {
       foreach (var propertyInfo in typeof(EmployeeInfo).GetProperties())
       {
           if (propertyInfo.Name.Contains("Name"))
           {
                typeof(SalaryDetails)
                    .GetProperty(prefix + propertyInfo.Name)
                    .SetValue(salaryDetails,
                        propertyInfo.GetValue(employeeInfo));
           }
       }
    }
