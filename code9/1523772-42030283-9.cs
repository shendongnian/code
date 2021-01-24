    public abstract class Pet : Animal
    {
        public string Name { get; set; }
        public PetAttributes Attributes { get; set; }
        public ICollection<Toy> Toys => Attributes.Toys;
    }
