    [HttpPost]
    public ReturnResponse  UpdateEmployeeApprovalStatus(object employeeInfo)
    {
         Employee emp= JsonConvert.DeserializeObject<Employee>(employeeInfo.ToString());
    }
