    public class Pizza
    {
        public int Id { get; set; }
        public virtual PizzaType PizzaType { get; set; }
        [ForeignKey("PizzaType ")]
        public int PizzaTypeId { get; set; }
    }
