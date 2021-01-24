    [HttpGet]
    public async Task<IActionResult> myControllerAction()
    {      
      var t1 = Task.Run(() => service.getdata1() );
      var t2 = Task.Run(() => service.getdata2() );
      var t3 = Task.Run(() => service.getdata3() );
    
      await Task.WhenAll(t1, t2, t3); // otherwise a thread will be blocked here
    
      var data = new returnObject
      {
          d1 = t1.Result,
          d2 = t2.Result,
          d2 = t3.Result
      };
    
     return Ok(data);
    }
