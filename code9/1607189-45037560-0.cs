    class Chicken
    {
        public enum ChickenStatus
        {
            Dead,
            Alive
        }
        public Chicken(int inNumber, ChickenStatus status)
        {
            this.Number = inNumber;
            this.Status = status;
        }
        public int Number { get; set; }
        public ChickenStatus Status { get; set; }
    }
