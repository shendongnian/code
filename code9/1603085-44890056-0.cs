    public async Task<IActionResult> Index(ConfigurationViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // Update
                var configurationClient = new ConfigurationClient();
                HttpResponseMessage response = await configurationClient.SetConfigurationValuesAsync(...);
                if (!response.IsSuccessStatusCode)
                {
                    // How to report back to user?
                       
                        return View(viewModel);
                }
            }
    
            return View(viewModel);
        }
