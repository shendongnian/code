    de.ComputerUserApplication
      .Where(x => x.EmployeeID == employeeID)
      .GroupJoin(
          de.ApplicationTypeMasters, 
          CUA => CUA.RecordType, 
          ATM => ATM.Code, 
          (CUA, ATM) => new ApplicationModel
          {
              ApplicationNo = CUA.ApplicationNo,
              ApplicationCode = CUA.RecordType,
              ApplicationTypeCode = "",
              ApplicationName = ATM.SingleOrDefault()?.Title + " - " + CUA.Description,
              Status = CUA.Status
          }
      );
