    [Table("Clothes")]
    public class Clothe
        {
            [Key]
            public int Id { get; set; }
            public ClothesType Type { get; set; }
            public int Amount { get; set; }
            [Range(10, 150)]
            public double Price { get; set; }
            public string ImagePath { get; set; }
            public ICollection<History> Histories { get; set; } 
            public History()
            {
                Histories = new List<History>();
            }
        }
    public class History
    {
        [Key]
        public int historyID { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public DateTime ShipDate { get; set; }
        public int Price { get; set; }
        [Required]
        public Clothe RelatedClothe { get; set; }
    }
