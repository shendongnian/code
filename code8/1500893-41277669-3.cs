    public class Pizza
    {
        public int Id { get; set; }
        public virtual PizzaType PizzaType { get; set; }
        [NotMapped]
        public int PizzaTypeId { get { return PizzaType.Id; } }
    }
