    using NUnit.Framework;
    namespace Tests
    {
        [TestFixture]
        [Category("Oracle")]
        public class OracleTests
        {
            [Test]
            public void OracleTest()
            {
                Assert.Fail();
            }
        }
        [TestFixture]
        [Category("OracleOdbc")]
        public class OracleOdbcTests
        {
            [Test]
            public void OracleOdbcTest()
            {
                Assert.Fail();
            }
        }
    }
