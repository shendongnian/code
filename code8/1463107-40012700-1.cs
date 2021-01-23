    [HttpPost]    
    public JsonResult MethodTest(string users)
                 {
                     string jdata = users.ToString();
                     List<StockAllocate> stockData;
                     bool status = false;
        
        
                        JavaScriptSerializer jss = new JavaScriptSerializer();
                        stockData = jss.Deserialize<List<StockAllocate>>(jdata);
                         status = true;
        
        
                     return new JsonResult { Data = new { status = status } };
                 }
