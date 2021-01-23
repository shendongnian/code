    public class AirplaneSeating
    {
        private List<Seat> seats;
        public AirplaneSeating()
        {
            seats = new List<Seat>();
            // Filling FC Rows
            for (byte row = 1; row <= 5; row++)
                for (byte column = 1; column <= 4; column++)
                    seats.Add(new Seat(row, column));
            // Filling EC Rows
            for (byte row = 6; row <= 35; row++)
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
                    return seats.First(
                        s => s.Position.Row == row && s.Position.Column.Name == col);
                }
                catch
                {
                    return null;
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
        public void ReserveSeat()
        {
            char ticketType = char.MinValue;
            byte passengersTogether = 0;
            int maxPassengersTogether;
            bool inputOk = false;
            while (ticketType != 'F' && ticketType != 'S')
            {
                Console.Write("Enter the ticket type (F = First Class, S = Second Class): ");
                ticketType = char.ToUpper(Console.ReadLine()[0]);
            }
            if (ticketType == 'F')
                maxPassengersTogether = 2;
            else
                maxPassengersTogether = 3;
            while (!inputOk && (passengersTogether < 1 || 
                passengersTogether > maxPassengersTogether))
            {
                Console.Write("Enter the number of passengers traveling together (1 or {0}): ",
                    maxPassengersTogether);
                inputOk = byte.TryParse(Console.ReadLine(), out passengersTogether);
            }
            for (byte passengerNumber = 1; 
                passengerNumber <= passengersTogether; 
                passengerNumber++)
            {
                Console.Write("Passenger {0} full name (BLOCK CAPITAL): ", passengerNumber);
                string passengerName = Console.ReadLine();
                Seat seat = null;
                string lastSeatAddress = null;
                // Choosen seat address must be valid (or else it will return null)
                // Choosen seat must match ticket type
                // Choosen seat must not be occupied
                while (seat == null || 
                    seat.Class != (ClassType)ticketType || 
                    seat.Status == SeatStatus.Occupied)
                {
                    if (seat != null)
                    {
                        if (seat.Class != (ClassType)ticketType)
                            Console.WriteLine("Seat does not match ticket type.");
                        if (seat.Status == SeatStatus.Occupied)
                            Console.WriteLine("This seat is occupied by {0}.",
                                seat.Passenger);
                    }
                    else
                    {
                        if (lastSeatAddress != null)
                            Console.WriteLine("Invalid seat address.");
                    }
                    Console.Write("Enter passenger seat (example: 1A): ");
                    lastSeatAddress = Console.ReadLine().ToUpper();
                    seat = this[lastSeatAddress];
                }
                seat.Passenger = passengerName;
                Console.WriteLine("Seat {0} reserved for passenger {1}.",
                    seat.Position, seat.Passenger);
            }
            Console.WriteLine("Reservation complete.");
            Console.WriteLine();
        }
        public void PrintPassengersToConsole()
        {
            var occupiedSeats = seats.Where(s => s.Status == SeatStatus.Occupied);
            if (occupiedSeats.Any())
            {
                Console.WriteLine("Seating\tPassenger Name");
                foreach (var seat in occupiedSeats
                        .OrderBy(s => s.Position.Row)
                        .ThenBy(s => s.Position.Column.Number))
                {
                    Console.WriteLine("{0}     \t{1}",
                        seat.Position,
                        seat.Passenger);
                }
            }
            else
            {
                Console.WriteLine("The airplane does not have any reservation.");
            }
            Console.WriteLine();
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
        public ClassType Class
        {
            get
            {
                // Remember to change this if you want more rows of FC
                if (Position.Row <= 5)
                    return ClassType.FirstClass;
                else
                    return ClassType.SecondClass;
            }
        }
    }
    // This enum represents the status of the Seat
    public enum SeatStatus
    {
        Available = '*',
        Occupied = 'X'
    }
    // This enum represents the class type of the Seat
    public enum ClassType
    {
        FirstClass = 'F',
        SecondClass = 'S'
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
