    using System.Data.Common;
    using System.Data.Common.Fakes;
    using System.Data.SqlClient;
    using System.Data.SqlClient.Fakes;
    using Microsoft.QualityTools.Testing.Fakes;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    [TestClass]
    public class FakeTest
    {
        [TestMethod]
        public void DownCast()
        {
            using (ShimsContext.Create())
            {
                SqlConnection sqlCn = new ShimSqlConnection
                {
                    CreateCommand = () => new ShimSqlCommand(),
                    CreateDbCommand = () => new ShimSqlCommand()
                };
                new ShimDbConnection(sqlCn) { CreateCommand = () => new ShimSqlCommand() }; // Adding this line, the test passes.
                Assert.IsNotNull(sqlCn.CreateCommand());
                DbConnection dbCn = sqlCn;
                Assert.IsNotNull(dbCn.CreateCommand());
            }
        }
    }
