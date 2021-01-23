	var customerInDb = _context.Customers
				.Single(c => c.Id == viewModel.Customer.Id);
	_context.Entry(customerInDb)
		.CurrentValues
		.SetValues(viewModel.Customer);
	var mailingAddressInDb = _context.Addresses
				.Single(m => m.Id = viewModel.Customer.MailingAddress.Id);
	_context.Entry(mailingAddressInDb)
		.CurrentValues
		.SetValues(viewModel.Customer.MailingAddress);
