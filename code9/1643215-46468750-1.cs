    public abstract class Animal
    {
        public string Name { get; set; }
        public int? CageID { get; set; }
        [ForeignKey("CageID")]
        public virtual Cage Cage { get; set; }
    }
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
