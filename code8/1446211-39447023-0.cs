    public override void Up()
    {
        //add new column:
        AddColumn("dbo.MyTable", "IsA2", c => c.Int(nullable: false));
        //transfer data to just created column
        Sql("Update dbo.MyTable set IsA2 = switch case when IsA then 0 else 1 end");
        //Drop old column
        DropColumn("dbo.MyTable", "IsA")
        //Rename new column to initial name
        Sql("EXEC sp_rename 'dbo.MyTable.IsA2', 'IsA', 'COLUMN'");            
    }
