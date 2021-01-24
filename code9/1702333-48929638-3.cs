    public abstract class SQLiteTestBase
    {
        public static ConnectionContext Connection { get; set; }
        public static FooDatabase Database { get; set; }
        [TestMethod]
        public void DoSomeFooTest()
        {
            Database.DoFoo();
        }
    }
    [TestClass]
    public class SQLiteTest : SQLiteTestBase
    {
        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {                 
            Database = new FooDatabase();            
            Database.GetContext = () => Connection;
            Connection = new ConnectionContext(Database.GetConnection(), false);            
        }
        [TestInitialize]
        public void TestInit()
        {
            Connection = new ConnectionContext(Database.GetConnection(), false);
            Database.Initialize();
        }
        [TestCleanup]
        public void TestCleanup()
        {
            Connection.Dispose();
            Connection = null;
        }
    }
