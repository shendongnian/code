        // POST: api/StartWorkingDays
            [System.Web.Http.AcceptVerbs("POST")]
            [System.Web.Http.HttpPost]
            [ResponseType(typeof(StartWorkingDay))]
            public IHttpActionResult PostStartWorkingDay()
            {
            	var startWorkingDay = JsonConvert.DeserializeObject<StartWorkingDay>(HttpContext.Current.Request.Form["startWorkingDay"]);
                //if (!ModelState.IsValid)
                //{
                //    return BadRequest(ModelState);
                //}
            
                db.StartWorkingDays.Add(startWorkingDay);
                db.SaveChanges();
            
                return CreatedAtRoute("DefaultApi", new { id = startWorkingDay.Id }, startWorkingDay);
            }
    
    
      [1]: https://i.stack.imgur.com/AF5YH.png
