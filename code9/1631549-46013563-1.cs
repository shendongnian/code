    [Fact]
    public void Parse()
    {
        void Test(string s, int expected)
        {
            Assert.True(ParseUtil.TryParse(s, out var actual));
            Assert.Equal(expected, actual);
        }
        
        void TestFails(string s) => Assert.False(ParseUtil.TryParse(s, out var _));
        Test("1234", 1234);
        Test("1234 ", 1234);
        Test("1234  ", 1234);
        Test("0X4D2", 1234);
        Test("0h4D2", 1234);
        Test("0x4d2", 1234);
        Test("0x4D2  ", 1234);
        Test("02322", 1234);
        Test("02322  ", 1234);
        Test("002322  ", 1234);
        Test("0002322  ", 1234);
        Test(" 1234", 1234);
        Test(" 1234 ", 1234);
        Test("  1234  ", 1234);
        Test(" 0X4D2", 1234);
        Test(" 0h4D2", 1234);
        Test(" 0x4d2", 1234);
        Test(" 0x4D2  ", 1234);
        Test(" 02322", 1234);
        Test(" 02322  ", 1234);
        Test(" 002322  ", 1234);
        Test(" 0002322  ", 1234);
        TestFails("Hello");
        TestFails("0Hello");
        TestFails("0xx1234");
        TestFails("04D2");
        TestFails("4D2");
        TestFails("098LKJ");
        TestFails("0x");
        TestFails("0x ");
        TestFails(" 0x ");
    }
