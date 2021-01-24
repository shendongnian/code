    public string PutCustomerVerificationData(string customerID, CustomerVerification customerVerification)
    {
          JavaScriptSerializer js = new JavaScriptSerializer();
          string requestBody = js.Serialize(customerVerification);
          string serviceResponse = bllCustomerDetails.PutCustomerVerificationData(customerID, requestBody).Replace("\"", "'");
          return serviceResponse;
    }
