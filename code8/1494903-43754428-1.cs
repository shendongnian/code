    using Xunit;
    namespace ErpWebApi.UnitTests
    {
       public class UnitTest1
       {
            [Fact]
            public void TestFail()
            {
                Assert.Equal(2, 3);
            }
    
            [Fact]
            public void TestSucess()
            {
                Assert.Equal(2, 2);
            }
        }
    }
