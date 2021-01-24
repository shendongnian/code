    [HttpPost]
            public ActionResult Index(string TaxType, string txtTax)
            {
                string finalVal = TaxType + txtTax;
                return View();
            }
