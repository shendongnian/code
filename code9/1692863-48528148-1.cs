    protected override void Up(MigrationBuilder migrationBuilder)
    {
    	var spPath = @"MyCompany.MyTemplate.EntityFrameworkCore\Migrations\Stored Procedures\testSP.sql";
    
    	var spMigratorPath = Path.Combine("..", spPath);
    
    	if (!File.Exists(spMigratorPath))
    	{
    		spMigratorPath = Path.Combine("..", "..", "..", "..", spPath);
    	}
    
    	migrationBuilder.Sql(File.ReadAllText(spMigratorPath));
    }
