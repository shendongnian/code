    var myCustomers = (from cc in context.ContractCustomers
    where cc.Contract_ID.Equals(contractID)
    select new
    {
        Licencee = cc.IsLicencee,
        Added = cc.AddedDate,
        Firstname = cc.Customer.FirstName,
        Lastname = cc.Customer.LastName,
        DOB = cc.Customer.DateOfBirth,
        Postcode = cc.Customer.PostCode,
        CustomerNumber = cc.CustomerNumber,
        listOfCustomers = cc.Customer.ToList() // <-Here, a list
    }
    )
