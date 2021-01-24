    [HttpPost] 
    public string callBcknd([FromBody]string body)
    {
       try
       {
          Log.Info(string.Format("{0}", body));
          //You must return something
          return "Post Realized";
       }
       catch(Exception ex)
       {
          return "error";
       }
    }
    
    //I like call async
    [HttpPost] 
    
    public async Task<IActionResult>callBcknd([FromBody]string body)
    {
       try
       {
          Log.Info(string.Format("{0}", body));
          //await "some action"
          //You can return OK("success") or an object
          return Ok(new { success = true, description = "callback sucesfully" });;
       }
       catch(Exception ex)
       {
                //You can return OK("error") or an object
          return Ok(new { success = false, description = ex.InnerException });;
       }
    }
