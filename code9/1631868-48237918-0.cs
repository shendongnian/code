     [AllowAnonymous]
        public async Task<ActionResult> LoginWithGoogle(string email, string ac)
        {
            var appType = StoreContext.GetApplicationType();
            var requestStoreFrontType = Request.Headers["StoreFrontType"];
            #region removing mobile header (for google)
            //if not removing, google Api will reject our request
            Request.RemoveHeaderIfExist("StoreFrontType");
            Request.RemoveHeaderIfExist("StoreFrontVersion");
            Request.RemoveHeaderIfExist("Client_Token");
            Request.RemoveHeaderIfExist("Content-Type");
            #endregion
            var _googleService = new GoogleExternalLoginService();
            var registerResult = _googleService.LoginExternal(ac, appType);
            if (registerResult.Status == ServiceResultStatus.Success)
            {
                var pass = defaultPass;
                var registermodel = new RegisterViewModel();
                registermodel.AcceptPolicy = true;
                registermodel.Email = email;
                registermodel.EnableNewsLetter = true;
                registermodel.Password = pass;
                string getTokenUrl = "";
            var existedUser = UserManager.FindByEmail(registermodel.Email);
                if (existedUser == null)
                {
                    var owinUser = new ApplicationUser { UserName = email, Email = email, RegistrationType = GetUserRegTypeByExternalProviderName("Google") };
   
                        var result = await UserManager.CreateAsync(owinUser, registermodel.Password);
                        if (!result.Succeeded)
                            return new DSJson(null, registerResult.Message, registerResult.Status);
                    getTokenUrl = Request.Url.Scheme + "://" + Request.Url.Authority 
                        +"/Token";
                }
                else
                {
                    ECS.Cache.CacheFacade.Store(ac, email, DateTime.Now.AddMinutes(2));
                    getTokenUrl = Request.Url.Scheme + "://" + Request.Url.Authority
                                  + "/Token" + $"?IsSSO=1&AuthCode={ac}";
                }
                var getTokenParams = new List<KeyValuePair<string, string>>();
                getTokenParams.Add(new KeyValuePair<string, string>("grant_type", "password"));
                getTokenParams.Add(new KeyValuePair<string, string>("username", registermodel.Email));
                getTokenParams.Add(new KeyValuePair<string, string>("password", registermodel.Password));
                var headers = new Dictionary<string, string>();
                //headers.Add("StoreFrontType", StoreContext.StoreFrontType);
                //headers.Add("StoreFrontVersion", StoreContext.StoreFrontVersion);
                //headers.Add("Client_Token", StoreContext.ClientToken);
                var tokenResponse = HttpHelper.CallService<object>(getTokenUrl, "Post", null, getTokenParams.ToArray(), headers).Data;
                return new DSJson(tokenResponse, isResultDataInServiceResult: true);
            }
            return new DSJson(null, "operation failed, auth_code is invalid", ServiceResultStatus.Fail);
        }
