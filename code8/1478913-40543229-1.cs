	public ActionResult Save(CustomerFormViewModel viewModel)
	{
		if (!ModelState.IsValid)
		{
			return View("CustomerForm", viewModel);
		}
		
        // Define state of whole graph with single line
		_context.AddOrUpdate(viewModel.Customer);
		_context.SaveChanges();
		return RedirectToAction("Index", "Customers");
	}
