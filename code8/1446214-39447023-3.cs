    public partial class fromBool2Enum : DbMigration
    {
        public override void Up()
        {
            //add new column:
            AddColumn("dbo.MyTable", "IsA_TEMP", c => c.Int());
            //transfer data to just created column
            Sql("Update dbo.MyTable set IsA_TEMP = case when IsA then 0 else 1 end");
            //0 and 1 is just example, correct it on your own, depending on enum's declaration
    
            //Drop old column
            DropColumn("dbo.MyTable", "IsA")
            //Rename new column to initial name
            Sql("EXEC sp_rename 'dbo.MyTable.IsA_TEMP', 'IsA', 'COLUMN'");            
        }
        public override void Down()
        {
             //corresponding reverse code...
        }       
    }
