    public class Plan
    {
        public int Id { get; set; }
        public int? PreviousPlanId { get; set; }
        public Plan PreviousPlan { get; set; }
        ...
    }
