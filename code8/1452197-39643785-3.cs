    public class FirstRun : DbMigration
    {    public override void Up()
         {
            Sql("alter table YourTable add constraint CT_DefaultGuid default newid() for YourColumn");
         }
    }
