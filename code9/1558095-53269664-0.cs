    public partial class QuanLySieuThiEntities : DbContext
    {
        //This is the default constructor
        public QuanLySieuThiEntities()
            : base("name=QuanLySieuThiEntities")
        {
        }
        //Add this constructor
        public QuanLySieuThiEntities(String connString)
            : base(connString)
        {
        }
    }
