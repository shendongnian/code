    class Horse
    {
        public int Id { get; set; }
        public Horse(int id)
        {
            Id = id;
        }
    }
    class Carriage
    {
        public int Id { get; set; }
        public Carriage(int id)
        {
            Id = id;
        }
    }
    public class HorseAndCarriage
    {
        public int HorseId { get; set; }
        public int CarriageId { get; set; }
        public HorseAndCarriage(int horseId, int carriageId)
        {
            HorseId = horseId;
            CarriageId = carriageId;
        }
    }
