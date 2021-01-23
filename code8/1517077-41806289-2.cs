         public override void Up()
                {
                    CreateTable(
                        "dbo.Customers",
                        c => new
                            {
                                Id = c.Int(nullable: false, identity: true),
                                Name = c.String(),
                                ZipCode = c.String(),
                            })
                        .PrimaryKey(t => t.Id);
                    Sql(@"CREATE FUNCTION [dbo].[CustomersByZipCode](@ZipCode nchar(5)) 
                    RETURNS TABLE 
                    RETURN 
                    SELECT [Id], [Name], [ZipCode] 
                    FROM [dbo].[Customers]  
                    WHERE [ZipCode] = @ZipCode");
            
                }
        
                public override void Down()
                {
                    DropTable("dbo.Customers");
                    Sql(@"Drop FUNCTION [dbo].[CustomersByZipCode]");
            
                }
