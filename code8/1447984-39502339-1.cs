        [HttpGet]
        public IActionResult Index1()
        {
            AccountDetailsViewModel model = new AccountDetailsViewModel();
            //model.AccountId = "1222222";
            model.m_newIVR = new IVRS();
            model.m_newIVR.Account = "122222";
            return View(model);
        }
        [HttpPost]
        public IActionResult Index1(AccountDetailsViewModel model)
        {
            return View(model);
        }
