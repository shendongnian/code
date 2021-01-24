        public class SeatRow
        {
            public int TotalSeats { get; private set; }
            public int RowNumber { get; private set; }
            public List<Seat> Seats { get; private set; }
            public SeatRow(int seatsInRow, int rowNumber)
            {
                TotalSeats = seatsInRow;
                RowNumber = rowNumber;
            }
            public bool TryAddSeatToRow(Seat seat)
            {
                if(Seats.Count <= TotalSeats && seat.RowNumber == RowNumber)
                {
                    Seats.Add(seat);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public IEnumerable<Seat> GetAvailableSeats()
            {
                return Seats.Where(seat => seat.IsSeatReserved == false);
            }
           
        }
