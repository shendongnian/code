    [ResponseType(typeof(StartWorkingDay))]
    public IHttpActionResult PostStartWorkingDay([FromBody]StartWorkingDay startWorkingDay)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        db.StartWorkingDays.Add(startWorkingDay);
        db.SaveChanges();
        return CreatedAtRoute("DefaultApi", new { id = startWorkingDay.Id }, startWorkingDay);
    }
