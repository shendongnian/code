    public JsonResult GetJsonPeople(int pageNo = 1, string searchString = "", string sortColumn = "LastName", string sortDirection = "asc")
    {
    	var ppl = db.People
    		.Where(p => p.FirstName.Contains(searchString) || p.LastName.Contains(searchString))
    		.Select(p => new {
    			BusinessEntityID = p.BusinessEntityID,
    			FirstName = p.FirstName,
    			MiddleName = p.MiddleName,
    			LastName = p.LastName,
    			Suffix = p.Suffix,
    			EmailPromotion = p.EmailPromotion,
    			ModifiedDate = p.ModifiedDate })
    		.OrderBy(sortColumn + " " + sortDirection)
    		;
    
    	totalRecords = ppl.Count();
    
    	if (pageSize > 0)
    	{
    		ppl = ppl.Skip((pageNo - 1) * pageSize).Take(pageSize);
    	}
    	// ViewBag.Search = search;
    	var obj = new { ppl = ppl, totalRecords = totalRecords };
    	var jsonResult = Json(obj, JsonRequestBehavior.AllowGet);
    	jsonResult.MaxJsonLength = int.MaxValue;
    	return jsonResult;
    }
