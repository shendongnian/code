    [HttpGet]
      [Route("{startDateUtc:datetime}/{endDateUtc:datetime}/{pageNumber?}", Name = "MyRoute")]
      [ResponseType(typeof(List<string>))]
      public IHttpActionResult GetData(DateTime? startDateUtc, DateTime? endDateUtc, int pageNumber = 1)
      {
         HandleData(DateTime.SpecifyKind(startDateUtc.Value, DateTimeKind.utc), DateTime.SpecifyKind(endDateUtc.Value, DateTimeKind.utc), pageNumber);
         return this.Ok();
      }
