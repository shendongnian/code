    public async Task<ActionResult> TestSSN()
    {
        try
        {
            var apiResponse = await GetUsTraceApiHealth().GetAwaiter().GetResult();
            string responseBody = await apiResponse.Content.ReadAsStringAsync().Result;
            return Json(responseBody, JsonRequestBehavior.AllowGet);
        }
        catch (Exception e)
        {                    
            throw new Exception(e.Message);
        }
    }
