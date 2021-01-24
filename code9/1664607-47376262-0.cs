    public static class PairsOfConnections
    {
        public static IEnumerable<Tuple<string, string>> GetAllPairsOfConnections(string[] input, string[] output)
        {
            var connectionsFromFirstInput = output.Select(o => new { Input = input[0], Output = o });
            var connectionsFromSecondInput = output.Select(o => new { Input = input[1], Output = o }).ToList();
            return from a in connectionsFromFirstInput
                   from b in connectionsFromSecondInput
                   where a.Output != b.Output
                   select new Tuple<string, string>(a.Input + a.Output, b.Input + b.Output);
        }
    }
    public class PairsOfConnectionsTests
    {
        [Test]
        public void TestGetAllPairsOfConnections()
        {
            string[] input = { "A", "B" };
            string[] output = { "1", "2", "3", "4" };
            IEnumerable<Tuple<string, string>> result = PairsOfConnections.GetAllPairsOfConnections(input, output);
            var expected = new List<Tuple<string, string>>
            {
                new Tuple<string, string>("A1","B2"),
                new Tuple<string, string>("A1","B3"),
                new Tuple<string, string>("A1","B4"),
                new Tuple<string, string>("A2","B1"),
                new Tuple<string, string>("A2","B3"),
                new Tuple<string, string>("A2","B4"),
                new Tuple<string, string>("A3","B1"),
                new Tuple<string, string>("A3","B2"),
                new Tuple<string, string>("A3","B4"),
                new Tuple<string, string>("A4","B1"),
                new Tuple<string, string>("A4","B2"),
                new Tuple<string, string>("A4","B3")
            };
            CollectionAssert.AreEquivalent(expected, result);
        }
    }
