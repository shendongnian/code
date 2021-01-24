    [Migration(1)]
    public class CreateUserTable : Migration
    {
        public override void Up()
        {
            Create.Table("Users");
        }
    
        public override void Down()
        {
            Delete.Table("Users");
        }
    }
 
