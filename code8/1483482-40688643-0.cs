    class RandomHotelId {
        Random r = new Random();
        public string RandomHotelID ()
        {
            return LHotels[r.next(0, LHotels.Count)].HotelId;
        }
    }
