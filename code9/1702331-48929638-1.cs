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
            SqliteBase.GetContext = () => Connection;
            Connection = new ConnectionContext(SqliteBase.GetConnection(), false);
            Database = new FooDatabase();
        }
        [TestInitialize]
        public void TestInit()
        {
            Connection = new ConnectionContext(SqliteBase.GetConnection(), false);
            Database.Initialize();
        }
        [TestCleanup]
        public void TestCleanup()
        {
            Connection.Dispose();
            Connection = null;
        }
    }
