      public async Task<IActionResult> Patch(int key, [FromBody] JToken deltaObj2) 
        {
            var jc = new Microsoft.AspNetCore.JsonPatch.Converters.JsonPatchDocumentConverter();
            var mem = new MemoryStream();
            var jw = new JsonTextWriter(new StreamWriter(mem));
            deltaObj2.WriteTo(jw);
            jw.Flush();
            mem.Position = 0;
            var jt = new JsonTextReader(new StreamReader(mem));
            var deltaObj = (JsonPatchDocument)jc.ReadJson(jt, typeof(JsonPatchDocument), new Car(), new JsonSerializer());
           
            var origCar = products.FirstOrDefault(f => f.Id == key);
            deltaObj.ApplyTo(origCar);
            TryValidateModel(origCar);
           
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.SelectMany(s => s.Value.Errors.Select(x => x.Exception.Message)));
            }
            return Updated(origCar);
        }   
