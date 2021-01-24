    public class SP
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public override string ToString()
        {
            var formattedName = (Name + " ").PadRight(13, '.');
            return $"{ID}: {formattedName} Started on: {StartDate:d}, Ended on: {EndDate:d}";
        }
    }
