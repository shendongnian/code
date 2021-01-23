    // POST: api/Events
    [HttpPost]
    public ActionResult PostEvent([FromBody] object savedEvent)
    {
        Event addedEvent = JsonConvert.DeserializeObject<Event>(savedEvent.ToString());
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
