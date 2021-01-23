        [ResponseType(typeof(Class1))]
        public async Task<IHttpActionResult> PostClass1(Class1 class1)
        {
            class1.ParentLookup();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Class1.Add(class1);
            await db.SaveChangesAsync();
            return CreatedAtRoute("DefaultApi", new { id = Class1.Id }, class1);
        }
