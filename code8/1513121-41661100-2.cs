          public ActionResult Index()
          {
            -- I hardcoded id because I donthave all view model but with this i was able to achieve the result you required.
            int BusId = 1;
            var _context = new TestContext();
            var busFromDb = _context.Buses.FirstOrDefault(c => c.Id == BusId);
            var seatsFromDb = busFromDb.BusSeats;
            var reduce = seatsFromDb - 1;
            if (busFromDb != null)
            {
                busFromDb.BusSeats = busFromDb.BusSeats - 1;
                var book = new Booking
                {
                    AvailableSeats = reduce,
                    BusId = BusId,
                    DateTime =DateTime.Now,
                    Bus = busFromDb
                };
                book.Bus = busFromDb;
                _context.Entry(busFromDb).State = EntityState.Modified;
               
                _context.Bookings.Add(book);
            }
            _context.SaveChanges();
            return View();
        }
