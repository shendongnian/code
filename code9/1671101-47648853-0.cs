    public async Task<JsonResult> addition(int firstNumber, int secondNumber)
           {
            try
            {
                var endpoint = string.Format("addition/{0}/{1}", firstNumber, secondNumber);
                var response = await client.GetAsync(endpoint);
                var result=await response.Content.ReadAsStringAsync();
                return new (JavaScriptSerializer().Serialize(new { Result = result});
            }
   
            catch (Exception e)            
            {
              return new (JavaScriptSerializer().Serialize(new { status = 
             "error", message = "Server is not running" });
            }
            
       } 
    
   
