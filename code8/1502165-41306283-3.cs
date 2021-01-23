    XNamespace ns = "http://website/xsd/MQ";
    var xmlDoc = new XElement(ns + "employees",
        from e in listEmployees
        select new XElement(ns + "employee",
            new XElement(ns + "id", e.EmployeeId),
            new XElement(ns + "first-name", e.FirstName),
            new XElement(ns + "last-name", e.LastName),
            new XElement(ns + "subarea", e.SubArea),
            new XElement(ns + "cost-center", e.CostCenter),
            new XElement(ns + "email-address", e.EmailAddress)
        )
    );
