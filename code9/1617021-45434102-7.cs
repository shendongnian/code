     [HttpPost]
     [Route("something")]
     // POST api/<controller>
     public async Task<HttpResponseMessage> Post(FormDataCollection form)
     {
         string tid = form.Get("tid");
         string sid = form.Get("sid");
         string userid = form.Get("userid");
         string udid = form.Get("udid");
             
      }
