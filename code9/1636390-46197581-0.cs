    [WebMethod, ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string GetBillableContracts(int reviewerId)
    {
      JavaScriptSerializer serializer = new JavaScriptSerializer();
      try{
          using (SPSite site = new SPSite(HttpContext.Current.Request.UrlReferrer.ToString()))
          {
            
            var contracts = FinanceTally.GetBillableReviewerContracts(reviewerId, site); //Here I throw an exception with custom message
            return serializer.Serialize(contracts);
        }
      }catch(Exception ex){
        // set status to 500 here and return you message
        HttpContext.Current.Response.StatusCode = 500;
        return serializer.Serialize(new { Message = ex.Message});
     }
    }
