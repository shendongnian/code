    [TestClass]
    public class ADPReportClassTest //<-- public
    {
        public TestContext TestContext { get; set; } //<-- public
        [TestMethod]
        [DataSource("System.Data.SqlClient", "Server=Localhost;Database=Test_Employee_Refresh;Integrated Security=Yes", "ADPREPORTCLASS_Tuples", DataAccessMethod.Sequential)]
        public void Checkconstructor() //<-- public
        {
            string filename = TestContext.DataRow["TestFileName"].ToString();
            Assert.AreEqual(filename, filename);
        }
    }
