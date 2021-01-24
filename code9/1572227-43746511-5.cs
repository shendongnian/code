     [HttpPut]
     public async Task<IHttpActionResult> Put([FromBody] List<A> alist)
     {
         if(!ModelState.IsValid) throw new InvalidDataException(ModelState,"Data Validation Failed for Upload Class A"); 
         
         var validator = new ClassACollectionValidator();
         var result = validator.Validate(alist)
     }
