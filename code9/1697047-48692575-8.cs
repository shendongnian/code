        public interface IRestrictedSeat
        {
            List<SeatRestriction> Restrictions { get; }
            bool AssertQualifiedPassenger(PassangerModel passenger);
        }
        public class Seat : ISeat, IRestrictedSeat
        {
            public bool IsSeatReserved { get { return Passenger != null; } }
            public int RowNumber { get; private set; }
            public string SeatLetter { get; private set; }
            public PassangerModel Passenger { get; private set; }
            public List<SeatRestriction> Restrictions { get; private set; }
            public Seat(int rowNumber, string seatLetter)
            {
                Restrictions = new List<SeatRestriction>();
                RowNumber = rowNumber;
                SeatLetter = seatLetter;
            }
            
            public bool TryAddPassenger(PassangerModel passanger)
            {
                if (AssertQualifiedPassenger(passanger))
                {
                    Passenger = passenger;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool AssertQualifiedPassenger(PassangerModel passenger)
            {
                foreach(SeatRestriction restriction in Restrictions)
                {
                    if (!restriction.Restriction(passenger))
                    {
                        return false;
                    }
                }
                return true;
            }
            
        }
