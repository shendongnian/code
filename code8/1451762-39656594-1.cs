    public async Task<ActionResult> test()
                {
                var user =  await new AzureADGraphTest.Users().GetUserByPrincipalName("userName@tenant.onmicrosoft.com");
    
                return View();
            }
