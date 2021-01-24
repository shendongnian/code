public partial class TestEntities: DbContext
{
    public TestEntities(string connectionString)
        : base(connectionString)
    {
    }
 - If you want then to interact with the database you need to retrieve the connection string from the app settings and then pass it over when initializing DbContext
string connectionString = Environment.GetEnvironmentVariable("connectionStringAppSettings");
using (var dbContext = new TestEntities(connectionString))
{
// Do Something
}
 - The problem with this approach is that every time you update the database you need to update the class "TestEntities" as it is overwritten
**Approach 2**
 - The goal here is to leave the class "TestEntities" as is to avoid the issue from Approach 1
 - Add the connection string to the App Settings (respectively local.settings.json) like in Approach 1
 - Leave TestEntities as is
public partial class TestEntities : DbContext
    {
        public TestEntities ()
            : base("name=TestEntities")
        {
        }
 - As TestEntities is partial you can extend that class by creating another one that is also partial with the same name in the same namespace. The goal of this class is to provide the constructor that takes the connection string as argument
public partial class TestEntities
{
    public TestEntities(string connectionString)
        : base(connectionString)
    {
    }
}
 - Then you can go on like with Approach 1
