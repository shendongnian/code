add-migration ClassName => add-migration FirstInitialize
2. After executing the code, the migration classes will be created for your models
c#
public partial class FirstInitialize : Migration
{
   protected override void Up(MigrationBuilder migrationBuilder)
   {
       //After executing the code, this section will be automatically   generated for your models 
   }
}
3. Then, with the following code you enter in the class section of the program.cs main method, your models will be built into a database.
 
c#
using (var scope = host.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<YouDbContext>();
        context.Database.Migrate();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while seeding the atabase.");
    }
}
4. Each time you change your models or add a new one, you have to repeat the steps. Choose a new name for your migration every time. Sample: `add-migration SecondInitialize`
