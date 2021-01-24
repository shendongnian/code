        adminPage
        [FindsBy(How = How.Id, Using = "City")]
        private readonly IWebElement _adminCity = null;
		//methods
		public void TypeAdminCity(string value)
        {
            browser.Type(_adminCity, value);
        }
        
        UserPage
        [FindsBy(How = How.Id, Using = "userCity")]
        private readonly IWebElement _userCity = null;
        //methods
		public void TypeUserCity(string value)
        {
            browser.Type(_userCity, value);
        }
