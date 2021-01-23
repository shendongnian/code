        // GET: api/Rates/5
        [ResponseType(typeof(Rate))]
        public IHttpActionResult Get(int id)
        {
            Rate rate = db.Rates.Find(id);
            if (rate == null)
            {
                return NotFound();
            }
            return Ok(rate);
        }
