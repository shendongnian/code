           public override void Up()
                {
                    CreateTable(
                        "dbo.Users",
                        c => new
                            {
                                Id = c.Int(nullable: false, identity: true),
                                Name = c.String(),
                            })
                        .PrimaryKey(t => t.Id);
                    Sql(@" CREATE FUNCTION [dbo].[GetUser](@ID int)
                        RETURNS TABLE
                        AS
                        RETURN 
                        (
                            SELECT *
                            FROM dbo.Users
                            WHERE Id = @ID
                        )");
            
                }
        
                public override void Down()
                {
                    DropTable("dbo.Users");
                    Sql(@" drop FUNCTION [dbo].[GetUser] ");
                }
