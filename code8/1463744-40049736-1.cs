    class Program
    {
        static void Main()
        {
            var graphA = Load("<http://example.com/subject> <http://example.com/predicate> \"object\".");
            var graphB = Load("<http://example.com/subject> <http://example.com/predicate> \"object\"^^<http://www.w3.org/2001/XMLSchema#string>.");
    
            var diff = graphA.Difference(graphB);
    
            Debug.Assert(diff.AreEqual);
        }
    
        private static IGraph Load(string source)
        {
            var result = new Graph();
            var graphHandler = new GraphHandler(result);
            var strippingHandler = new StripStringHandler(graphHandler);
            var parser = new TurtleParser();
    
            using (var reader = new StringReader(source))
            {
                parser.Load(strippingHandler, reader);
            }
    
            return result;
        }
    }
