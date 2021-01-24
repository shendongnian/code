    KRAParameter = (null != itemEmployees[Business.Enums.Employees.Designation.ToString()])
        ? kraParameterColl.FirstOrDefault(tempKRAParameter => 
            tempKRAParameter.Designation == Convert.ToString(
                itemEmployees[Business.Enums.Employees.Designation.ToString()]).Split('#')[1])
        : string.Empty
