    public class AirplaneSeating
    {
        private List<Seat> seats;
        public AirplaneSeating()
        {
            seats = new List<Seat>();
            // Filling FC Rows
            for (byte row = 1; row <= 2; row++)
                for (byte column = 1; column <= 4; column++)
                    seats.Add(new Seat(row, column));
            // Filling EC Rows
            for (byte row = 3; row <= 5; row++)
                for (byte column = 1; column <= 6; column++)
                    seats.Add(new Seat(row, column));
        }
        // You can use this indexed property to search for a seat by it's address
        public Seat this[string address]
        {
            get
            {
                try
                {
                    var row = byte.Parse(address.Substring(0, 1));
                    var col = address[1];
                    return seats.FirstOrDefault(
                        s => s.Position.Row == row && s.Position.Column.Name == col);
                }
                catch
                {
                    throw new ArgumentException("Invalid seat address.");
                }
            }
        }
        // You can use this indexed property if you need to loop through seats
        public Seat this[byte row, byte column]
        {
            get
            {
                return seats.FirstOrDefault(
                    s => s.Position.Row == row && s.Position.Column.Number == column);
            }
        }
        // This method can be used to find a seat occupied by a passenger
        public Seat FindSeatOccupiedBy(string passengerName)
        {
            return seats.FirstOrDefault(
                s => s.Passenger.ToUpper().Contains(passengerName.ToUpper()));
        }
        // This method can be called to print the seating to console, like you needed
        public void PrintToConsole()
        {
            Console.Write("Key: " + "* - Available " + " X - Occupied" + "\n" + "\n");
            Console.Write("     \tA\tB\tC\tD\tE\tF");
            Console.WriteLine();
            foreach (var row in seats.GroupBy(s => s.Position.Row)
                .OrderBy(r => r.Key))
            {
                Console.Write(string.Format("Row {0}\t", row.Key));
                foreach (var column in row.GroupBy(s => s.Position.Column.Number)
                    .OrderBy(c => c.Key))
                {
                    foreach (var seat in column)
                    {
                        Console.Write((char)seat.Status);
                        Console.Write("\t");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
    // This class represents your Seat
    public class Seat
    {
        public Seat(byte row, char column)
        {
            Position = new SeatPosition(row, column);
        }
        public Seat(byte row, byte column)
        {
            Position = new SeatPosition(row, column);
        }
        // Set Passenger to null to make the seat available.
        public string Passenger { get; set; }
        public SeatPosition Position { get; private set; }
        public SeatStatus Status
        {
            get
            {
                // When you assign a passenger to a seat, status will change
                if (Passenger == null)
                    return SeatStatus.Available;
                else
                    return SeatStatus.Occupied;
            }
        }
    }
    // This enum represents the status of the Seat
    public enum SeatStatus
    {
        Available = '*',
        Occupied = 'X'
    }
    // This class represents a seat position
    public class SeatPosition
    {
        public SeatPosition(byte row, char column)
        {
            Row = row;
            Column = new SeatColumn(column);
        }
        public SeatPosition(byte row, byte column)
        {
            Row = row;
            Column = new SeatColumn(column);
        }
        public byte Row { get; private set; }
        public SeatColumn Column { get; private set; }
        public override string ToString()
        {
            return string.Format("{0}{1}", Row, Column.Name);
        }
    }
    // This class is to help defining and printing seat columns
    public class SeatColumn
    {
        public SeatColumn(byte number)
        {
            Number = number;
        }
        public SeatColumn(char name)
        {
            Name = name;
        }
        public byte Number { get; set; }
        public char Name
        {
            get { return NumberToName(Number); }
            set { Number = NameToNumber(value); }
        }
        private static char NumberToName(byte number)
        {
            switch (number)
            {
                case 1:
                    return 'A';
                case 2:
                    return 'B';
                case 3:
                    return 'C';
                case 4:
                    return 'D';
                case 5:
                    return 'E';
                case 6:
                    return 'F';
            }
            throw new Exception("Invalid column number.");
        }
        private static byte NameToNumber(char name)
        {
            switch (name)
            {
                case 'A':
                    return 1;
                case 'B':
                    return 2;
                case 'C':
                    return 3;
                case 'D':
                    return 4;
                case 'E':
                    return 5;
                case 'F':
                    return 6;
            }
            throw new Exception("Invalid column name.");
        }
    }
