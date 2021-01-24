    public IHttpActionResult SampleActionMethod(SampleViewModel model) {
         if (!ModelState.IsValid) {
              return BadRequest();
         }
         var sampleDbModel = new SampleDatabaseModel() {
              FullName = model.Name,
              ProductId = model.Id,
              // ... some other properties ...
         };
         // ... Save the sampleDbModel ...
         return Ok(); // .. or Created ...
    }
