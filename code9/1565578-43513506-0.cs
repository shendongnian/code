    public partial class SetDeletedFlagTrue : DbMigration {
        public override void Up() {
            const string update = "UPDATE MyTable SET [Del_flg] = 1";
            Sql(update);
        }
    
        public override void Down() { /* ... */}
    }
