    [HttpPost]
            public ActionResult Index(ConvertCurrencyViewModel cur)
            {
                if (ModelState.IsValid)
                {
    
                        string fromcurrname = cur.fromCurrency.Name;
                        string tocurrname = cur.toCurrency.Name;
    
                        //rate is taking by passing both dropdown currency code
                        decimal rate = CurrencyClient.GetConversionRate("Currency/GetConversionRate?fromcurrname=" + fromcurrname + "&tocurrname=" + tocurrname).Result;
                        ViewBag.result = cur.CurrencyToConvert * rate;
    
                }
                    //getting this select list value form Currency client class
                    var fromCurrencyList = CurrencyClient.GetFromCurrencyListAsync().Result;
    
                    ViewBag.FromCurrencies = new SelectList(fromCurrencyList, "CurrencyCode", "Name");
    
                    var ToCurrencyList = CurrencyClient.GetToCurrencyListAsync().Result;
    
                    ViewBag.ToCurrencies = new SelectList(ToCurrencyList, "CurrencyCode", "Name");
    
                    return View();
                
            }
