    public class TestReporting {
      public static IEnumerable<object[]> BoolTestData() {
        yield return new object[] { true, true };
        yield return new object[] { true, false };
      }
      [Theory, MemberData(nameof(BoolTestData))]
      public void CheckBoolEquality(bool b1, bool b2) {
        Assert.Equal(b1, b2);
      }
      public static IEnumerable<(string, Expression<Func<string, string>>, string)> RawTestData() {
        yield return ("Hello", str => str.Substring(3), "lo");
        yield return ("World", str => str.Substring(0, 4), "worl");
      }
      public static IEnumerable<object[]> StringTestData() {
        return RawTestData().Select(vt => new object[] { vt.Item1, vt.Item2, vt.Item3 });
      }
      [Theory, MemberData(nameof(StringTestData))]
      public void RunStringTest(string input, Expression<Func<string, string>> func, string expectedOutput) {
        var output = func.Compile()(input);
        Assert.Equal(expectedOutput, output);
      }
    }
