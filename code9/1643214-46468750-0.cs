    public class Bird : Animal
    {
        [Key]
        public int ID { get; set; }
        public bool CanFly { get; set; }
    }
    public class Shark : Animal
    {
        [Key]
        public int ID { get; set; }
        public bool CanSwim { get; set; }
    }
