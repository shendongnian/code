    [HttpPost]
    public ActionResult Index(Currencies cur)
    {
            if (ModelState.IsValid)
            {
                if (cur.FromCurrencyId == cur.ToCurrencyId)
                {
                    //do something if same currecnies and return.
                    ModelState.AddModelError("CurrencyCountry", "Can't make the conversion for the same value");
                }
                else
                {
                   some code .....
                }
            }
            CurrenciesClient Cur = new CurrenciesClient();
            var listCurrency = Cur.findAll().ToList();
            Currencies model = new Currencies();
            model.FromCurrencies = new SelectList(listCurrency, "Id", "CurrencyName");
            model.ToCurrencies = new SelectList(listCurrency, "Id",  "CurrencyName");
            return View(cur);
        }
