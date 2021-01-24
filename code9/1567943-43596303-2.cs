    public class ItemsModel
    {
        public int ID { get; set; }
        public string Item_Name { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal Price { get; set; }
        public int TimeSlot { get; set; }
        public bool Food_AddOns { get; set; }
        public bool Drink_AddOns { get; set; }
        [ForeignKey("Item_Description")]
        public virtual int Item_Description_ID { get; set; }
        public virtual Item_Description Item_Description { get; set; }
        [ForeignKey("Item_Status")]
        public virtual int Item_Status_ID { get; set; }
        public virtual Item_Status Item_Status { get; set; }
        [ForeignKey("Dinner")]
        public virtual int Dinner_ID { get; set; }
        public virtual Dinner Dinner { get; set; }
        public string Ingredients { get; set; }
    }
