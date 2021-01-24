	public IActionResult Index()
	{
		var vm = from p in db.Person
				 where p.BusinessEntityId == 1
				 select new PersonIndexViewModel
				 {
					 Person = p,
					 PersonPhone = p.PersonPhone.FirstOrDefault(),
					 EmailAddress = p.EmailAddress.FirstOrDefault()
				 };
	
	
		return View(vm.FirstOrDefault());
	}
