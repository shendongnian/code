    query.ToList().Select(AS_ProjectHeader =>
    {
            ID = AS_ProjectHeader.ID,
            PartyID = AS_ProjectHeader.PartyID,
            Name = AS_ProjectHeader.Name + "  Employee ID: " + AS_ProjectHeader.EmployeeID + " Employee Name:" + AS_ProjectHeader.PAYE_Employee.Forenames + " " + AS_ProjectHeader.PAYE_Employee.Surname,
            ClientName = AS_ProjectHeader.AS_PartyList.Name,
            StartDate = AS_ProjectHeader.StartDate,
            EndDate = AS_ProjectHeader.EndDate,
    }
