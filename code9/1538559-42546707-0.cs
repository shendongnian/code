    public TestContext TestContext { get; set; }
    public DataRow DataRow { get; set; }
           
    [DataSource("Microsoft.VisualStudio.TestTools.DataSource.TestCase", "http://serverName:8080/tfs/MyCollection;teamProjectName", "541", DataAccessMethod.Sequential)]
    
    [TestMethod]
    public void TestMethod()
    {
                string parameter1 = TestContext.DataRow[0].ToString(); // read parameter by column index
                string parameter2 = TestContext.DataRow[1].ToString(); 
    
                var sut = new Class1();
    
                var result = sut.Add(a, b);
    
                Assert.AreEqual(parameter1, result);
    }
