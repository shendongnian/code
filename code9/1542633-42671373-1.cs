    public class Data {
        public List<TestItem> Tests {get; set;}
        public List<Tuple<string, decimal, decimal>>  AllGraphSamples
        {
            get
            {
                var allGraphData = new List<Tuple<string, decimal, decimal>>();
                foreach (var test in Tests)
                {
                    var graphData = test.GraphData.Samples.Select(
                        s => new Tuple<string, decimal, decimal>
                                 (
                                 string.Format("Test {0}", test.TestNumber),
                                 s.Item1,
                                 s.Item2
                                 )).ToList();
                    allGraphData.AddRange(graphData);
                }
                return allGraphData;
            }
        }
