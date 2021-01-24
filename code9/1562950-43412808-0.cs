    public class Booking : ICloneable
    {
        public Booking Clone()
        {
            return new Booking() { RoomID = this.RoomID, etc. };
        }
        object ICloneable.Clone()
        {
            return this.Clone();
        }
    }
