       public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc();
    
        // Add the temp data provider
        services.AddSingleton<ITempDataProvider, CookieTempDataProvider>();
    }
    [HttpPost]
    public IActionResult Edit(User user)
    {
        _userRepository.Save(user);
        TempData["User"] = JsonConvert.SerializeObject(user);
        return RedirectToAction("Edit", new { id = user.Id });
    }
