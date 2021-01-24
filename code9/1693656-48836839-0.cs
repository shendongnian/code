    public static IRestResponse SendSimpleMessage(string email)
        {
            var order = new CustomerOrder();
            RestClient client = new RestClient();
            client.BaseUrl = new Uri("https://api.mailgun.net/v3");
            client.Authenticator =
                    new HttpBasicAuthenticator("api",
                                               "key-MINE");
            RestRequest request = new RestRequest();
            request.AddParameter("domain",
                                 "DOMAINHERE.mailgun.org", ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", "Shop Staff <postmaster@EMAILTHING>");
            request.AddParameter("to", email);
    	request.AddParameter("cc", "Shop Staff <insert email here>");
            request.AddParameter("subject", "Your Order has been placed");
            request.AddParameter("text", "Thank you for placing an order with our shop, we have just begun processing your order. You will recieve a follow up email when your order is ready for collection");
            request.Method = Method.POST;
            return client.Execute(request);
        }
