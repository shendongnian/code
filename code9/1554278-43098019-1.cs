    var contacts = (from x in db.ContactSet
                   select new
                   {
                       x.AccountId,
                       x.FirstName,
                       x.LastName,
                       x.FullName,
                       x.JobTitle,
                       x.ParentCustomerId,
                       x.EMailAddress1,
                       x.Telephone1,
                       x.MobilePhone,
                       x.Fax,
                       x.GenderCode,
                       x.BirthDate
                   }).ToList();
    var result = new ItemsWithTotal<ContactSet>(){
         Current = 1,
         RowCount = 10,
         Total = 1123,
         Rows = contacts
    }
    return Json(result);
