    public abstract class BaseTest
    {
        protected void RunTest(string expected, string actual)
        {
            Assert.Equal(expected, actual);
        }
    }
    
    public class ComplexTest : BaseTest
    {
        static IEnumerable<object[]> Data() = 
        {
            { "a", "a" }
        }
    
        [Theory, MemberData(nameof(Data))]
        void TestData(expected, actual) => base.RunTest(expected, actual);
    }
