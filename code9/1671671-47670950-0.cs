    public class ObjectModel
    {
        public int ID { get; set; }
        public int ObjectTypeID { get; set; }
        [StringLength(10)]
        public string ObjectTypeDiscriminator { get; set; }
    }
    public interface IObjectTypeModel
    {
        int ID { get; set; }
        string Data { get; set; }
    }
    // ObjectTypeDiscriminator = "Type1"
    public class ObjectType1Model : IObjectTypeModel
    {
        public int ID { get; set; }
        [StringLength(100)]
        public string Data { get; set; }
    }
    // ObjectTypeDiscriminator = "Type2"
    public class ObjectType2Model : IObjectTypeModel
    {
        public int ID { get; set; }
        [StringLength(100)]
        public string Data { get; set; }
    }
    class DbC : DbContext
    {
        public DbC()
        {
        }
        public DbSet<ObjectModel> Objects { get; set; }
        public DbSet<ObjectType1Model> Type1Objects { get; set; }
        public DbSet<ObjectType2Model> Type2Objects { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
