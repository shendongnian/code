    public abstract class BaseTest
    {
        [Theory]
    #pragma warning disable xUnit1015 // MemberData must reference an existing member
        [MemberData(nameof(Data))]
    #pragma warning restore xUnit1015 // MemberData must reference an existing member
        public void TestData(string expected, string actual)
        {
            // assert goes here
        }
    }
    
    public class ComplexTest : BaseTest
    {
        public static IEnumerable<object[]> Data()
        {
            return data;
            // data goes here
        }
    }
