    public class Petrol : EntityData
    {
        public int Mileage { get; set; }
        public DateTime PurchaseDate { get; set; }
        public float Quantity { get; set; }
        public Decimal Cost { get; set; }
        public string Station { get; set; }
        public string Claim_Id { get; set; }
        [ForeignKey("Claim_Id")]
        public virtual Claim Claim { get; set; }
    }
