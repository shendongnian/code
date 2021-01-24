    [Table("ItemTable")]
    public partial class ItemTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ItemID { get; set; }
        [StringLength(50)]
        public string ItemName { get; set; }
    }
    static void Main(string[] args)
        {
            List<ItemTable> ItemsList = new List<ItemTable>
            {
                new ItemTable { ItemID=1, ItemName="one" },
                new ItemTable { ItemID=2, ItemName="two" },
                new ItemTable { ItemID=3, ItemName="three" }
            };
            TestDbContext testDbContext = new TestDbContext();
            try
            {
                testDbContext.Database.Connection.Open();
                testDbContext.Database.ExecuteSqlCommand(@"SET IDENTITY_INSERT [TestDB].[dbo].[ItemTable] ON");
                testDbContext.ItemTables.AddRange(ItemsList);
                testDbContext.SaveChanges();
            }
            finally
            {
                testDbContext.Database.Connection.Close();
            }
        }
