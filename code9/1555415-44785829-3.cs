    public JsonResult IndexJson(RequestData model)
    {
         var searchPhrase = model.Search;
         if (!string.IsNullOrWhiteSpace(searchPhrase))
         {
             //Notice that the select columns match the ContactSetDTO properties
             string query = @"SELECT TOP " + model.RowCount + " s.AccountId, s.FirstName, s.LastName, s.FullName, s.JobTitle, s.ParentCustomerId, s.EmailAddress1, s.Telephone1, s.MobilePhone, s.Fax, s.GenderCode, s.BirthDate FROM ContactSet s WHERE s.FirstName LIKE '%' + @p0 + '%' OR s.LastName LIKE '%' + @p0 + '%')";
       //Then, this should return a list of ContactSetDTO for you
        var result = db.Database.SqlQuery<ContactSetDTO>(query, new System.Data.SqlClient.SqlParameter(parameterName: "@p0", value: searchPhrase)).ToList();
         var totalRows = getContactSetCount(searchPhrase);
         var tResult = new { rows = result, rowCount = model.RowCount, total = totalRows, current = model.Current, searchPhrase = model.Search }
        };
        return Json(tResult, JsonRequestBehavior.AllowGet);
    }
