    de.ComputerUserApplication
      .Where(x => x.EmployeeID == employeeID)
      .GroupJoin(
          de.ApplicationTypeMasters, 
          CUA => CUA.RecordType, 
          ATM => ATM.Code, 
          (x, y) => new { CUA = x, ATMs = y.DefaultIfEmpty() }
      ).SelectMany(x => x.ATMs.Select(ATM => new ApplicationModel
          {
             ApplicationNo = x.CUA.ApplicationNo,
             ApplicationCode = x.CUA.RecordType,
             ApplicationTypeCode = "",
             ApplicationName = ATM?.Title + " - " + x.CUA.Description,
             Status = x.CUA.Status
          }
      );
