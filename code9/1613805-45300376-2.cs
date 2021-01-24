    PayeeContactGroup payeeContactDetails = new PayeeContactGroup();
    
    var response = httpClient.GetAsync(uri).Result;
    if (response.IsSuccessStatusCode)
    {
       string data = response.Content.ReadAsStringAsync().Result;
       var payeeContactGroupDetails = JsonConvert.DeserializeObject<PayeeContactGroup>(data);
    
       if(payeeContactGroupDetails.PayeeContact != null && payeeContactGroupDetails.currentPage == 1)
        {
           payeeContactDetails.PayeeContact = payeeContactGroupDetails.PayeeContact.ToList();
        }
        else if(payeeContactGroupDetails.PayeeContact != null && payeeContactGroupDetails.currentPage > 1)
        { 
             if(payeeContactDetails.PayeeContact == null)
             {
                  payeeContactDetails.PayeeContact = new List<PayeeContactDetails>();
             }
             {payeeContactDetails.PayeeContact.AddRange(payeeContactGroupDetails.PayeeContact); // error at this line 
        }
          .......
          ......
    } 
