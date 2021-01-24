	public List<SomeClass> GetPage(string pagenumber)
	{
		int pager = Convert.ToInt32(pagenumber);
		int totalRecDisplay = 10;
		var TotlaRecords = (from n in db.Employee
							orderby n.Emp_Id
							select n);
							
		var count = TotlaRecords.Count()
	
		var pagination = from e in TotlaRecords
		                            .Skip((pager - 1) * totalRecDisplay)
		 							.Take(totalRecDisplay)
					 select new SomeClass
					 {
						 countRec = count,
						 Entity = e
					 };
		return pagination.ToList();
	
	}
