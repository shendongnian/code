    [Table("DonHang")]
    public partial class DonHang
    {
        ...
        public int? kid { get; set; }
        ...
        public virtual Kho Kho { get; set; }
    }
