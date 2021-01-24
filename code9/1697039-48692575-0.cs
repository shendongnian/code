        public interface ISeat
        {
            int RowNumber { get; }
            string SeatLetter { get; }
            PassangerModel Passenger { get; }
        }
