      public void PostProcessPayment(PostProcessPaymentRequest postProcessPaymentRequest)
        {
        
        string orderNo = postProcessPaymentRequest.Order.Id.ToString();
        string amount = postProcessPaymentRequest.Order.OrderTotal.ToString("0.00", CultureInfo.InvariantCulture);
        string merchantId = _NetConnectPaymentSettings.CustomerId;  
        string date = DateTime.Now.ToString("dd/MM/yyyy");
        string time = DateTime.Now.ToString("HH:mm:ss");
        string urlNetConnect = _NetConnectPaymentSettings.PaymentPage;
        string checksum = Generate_MerchantRequest_Check_Sum("7C12B6AECC51A3F3189799098AB1981", merchantId, orderNo, amount, date, time);
        var client = new HttpClient();
        var values = new List<KeyValuePair<string, string>>();
        values.Add(new KeyValuePair<string, string>("Merchant_ID", merchantId));
        values.Add(new KeyValuePair<string, string>("Order_NO", orderNo));
        values.Add(new KeyValuePair<string, string>("Order_Amount", amount));
        values.Add(new KeyValuePair<string, string>("Date", date));
        values.Add(new KeyValuePair<string, string>("Time", time));
        values.Add(new KeyValuePair<string, string>("CheckSum", checksum));
        values.Add(new KeyValuePair<string, string>("Transaction_Desc", "Shop From SM Motors"));
        var content = new FormUrlEncodedContent(values);
        //HttpResponseMessage response = client.PostAsync("http://www.smmotors.org", content).Result;
        
    HttpResponseMessage response = client.PostAsync(urlNetConnect, content).Result;
        if (response.IsSuccessStatusCode)
        {
            var responseString = response.Content.ReadAsStringAsync();
            HttpContext.Current.Response.Write(responseString.Result);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
            HttpContext.Current.Response.End();
            _webHelper.IsPostBeingDone = true;
        }
        else
        {
            throw new NopException();
        }
 
           return;
    }
