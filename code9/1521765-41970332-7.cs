    [HttpGet]
    [ActionName("GetReservationByDate")]
    [ResponseType(typeof(Reservation))]
    public IHttpActionResult GetReservationByDate(DateTime? date) {    
        if(date.HasValue) {
            var reservation = db.Reservations.Where(d => d.Value.Date.Equals(date)).ToList();
            if (reservation.Count == 0) {
                return NotFound();
            }
            return Ok(reservation);
        }
        return BadRequest();
    }
