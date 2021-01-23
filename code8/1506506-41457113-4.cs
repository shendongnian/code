      from CUA in de.ComputerUserApplication
      join x in de.ApplicationTypeMasters on CUA.RecordType equals x.Code into g
      from ATM in g.DefaultIfEmpty()
      select new ApplicationModel()
      {
         ApplicationNo = CUA.ApplicationNo,
         ApplicationCode = CUA.RecordType,
         ApplicationTypeCode = "",
         ApplicationName = ATM?.Title + " - " + CUA.Description,
         Status = CUA.Status
       };
      
