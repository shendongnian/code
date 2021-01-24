    public abstract class Pet : Animal
    {
        public PetAttributes Attributes { get; set; }
    }
    public class PetAttributes
    {
        [Key]
        public int OwnerId { get; set; }
        [ForeignKey(nameof(OwnerId))]
        public Pet Owner { get; set; }
        public virtual ICollection<Toy> Toys { get; set; }
    }
    public class Toy
    {
        public int Id { get; set; }
        public PetAttributes Owner { get; set; }
    }
