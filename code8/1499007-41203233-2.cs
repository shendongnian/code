	[HttpPost]
	public ActionResult Index(ConversionModel curModel)
	{
		if(ModelState.IsValid)
		{
			if(curModel.FromCurrencyId ==curModel.ToCurrencyId)
			{
				//do something if same currecnies and return.
			}
			else
			{
				//Get the currencyList with rates  from db
				//use currency ToCurrencyId and FromCurrencyId to fetch the 2 currencies
				// perform conversion with curModel.ConversionRate with existing logic
			} 
		}
		//Don'f forget to rebuild the Select Lists... 
		return View(curModel);
	}
