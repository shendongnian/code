    [HttpGet]
      [Route("getList")]
      public IHttpActionResult func([FromUri] int? value)
      {
          if (Request.Headers == null || !Request.Headers.Contains("token") || Request.Headers.GetValues("token").First() != ConfigurationManager.AppSettings["token"])
              return NotFound();  //works but triggers a object null reference exeption
          return Ok(new List<_Type>());
      }
