    public async Task<IActionResult> YourWebApiMethod() {
      // at this point thread serving this request is returned back to threadpool and   
      // awailable to serve other requests
      return await Call3ptyService();
    }
    // thread serving this request is allocated for duration of whole operation 
    public IActionResult YourWebApiMethod() {
      return Call3ptyService().Result;
    }
