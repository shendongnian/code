    public partial class Inventory
    {
        public string BookID { get; set; }
        public short TotalIn { get; set; }
        public short LowIn { get; set; }
        public short Out { get; set; }
    
        public virtual BookInfo BookInfo { get; set; }
    }
