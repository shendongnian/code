    public async Task<IActionResult> Add()
    {
        var model = new AddAccountViewModel();
        ConfigureViewModel(model);
        return View(model);
    }
    
    [HttpPost]
    public async Task<IActionResult> Add(AddAccountViewModel model)
    {
        if (!ModelState.IsValid)
        {
            ConfigureViewModel(model);
            return View(model);
        }
        ....
    }
    private void ConfigureViewModel(AddAccountViewModel model)
    {
        var client = await _clientFactory.CreateClientAsync();
        var accountTypes = await client.GetAccountTypesAsync();
        model.AccountTypes = new SelectList(accountTypes, "Id", "Name");
    }
    
