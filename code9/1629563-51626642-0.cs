            string URI = "https://oauth.platform.intuit.com/oauth2/v1/tokens/bearer";
            string myParameters = "grant_type=refresh_token&refresh_token=L0115-----------------------------------"; // Put Refresh Token
            WebClient wc = new WebClient();
            wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
            wc.Headers[HttpRequestHeader.Accept] = "application/json";
            wc.Headers[HttpRequestHeader.Authorization] = "Basic UT------------------------------hcW5SV---------------------Qg==";  // Add Auth Token
            string HtmlResult = wc.UploadString(URI, myParameters);
            wc.Dispose();
            var jobject = JsonConvert.DeserializeObject<Test>(HtmlResult);
            string accessToken = jobject.access_token;
            string relmid = "123412341234123421341234";  // Relmid 
            OAuth2RequestValidator oauthValidator = new OAuth2RequestValidator(accessToken);
            ServiceContext serviceContext = new ServiceContext(relmid, IntuitServicesType.QBO, oauthValidator);
            serviceContext.IppConfiguration.BaseUrl.Qbo = "https://sandbox-quickbooks.api.intuit.com/";
            //serviceContext.IppConfiguration.BaseUrl.Qbo = "https://quickbooks.api.intuit.com/";//prod
            serviceContext.IppConfiguration.MinorVersion.Qbo = "23";
            CustomerCRUD.CustomerAddTestUsingoAuth(serviceContext);
            CustomerCRUD.CustomerFindAllTestUsingoAuth(serviceContext);
