    public class ContacModel{
    {
        public  int AddressID { get; set; }
        [ForeignKey("AddressID")]
        public virtual Addresses Address { get; set; }
    }
