    [CodedUITest]
    public class ManyTests
    {
        [TestMethod]
        public string MyFirstTest()
        {
            string a = "AAA";            
            return RunLookupMyString(a);
        }
    }
    public static string RunLookupMyString(string a)
    {
        string b = a + " [modified by RunLookupMyString]";
        return b;
    }
