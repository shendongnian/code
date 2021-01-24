    public class Order
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrderNumber { get; set; }
        ...
    }
