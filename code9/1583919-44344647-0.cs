    public class BaseTest
    {
        [Theory]
        [MemberData(nameof(TestScenarios1.Data), MemberType = typeof(TestScenarios1)]
        [MemberData(nameof(TestScenarios1.MoreData), MemberType = typeof(TestScenarios1)]
        [MemberData(nameof(TestScenarios2.DifferentData), MemberType = typeof(TestScenarios2)]
        public void TestData(string expected, string actual)
        {
            // assert goes here
        }
    }
    public class TestScenarios1
    {
        public static IEnumerable<object[]> Data()
        {
            // data goes here
        }
        public static IEnumerable<object[]> MoreData()
        {
            // data goes here
        }
    }
    public class TestScenarios2
    {
        public static IEnumerable<object[]> DifferentData()
        {
            // data goes here
        }
    }
