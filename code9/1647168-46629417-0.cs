    public class CustomObject
    {
    }
    public class ListInitiator
    {
        [Benchmark]
        public List<CustomObject> InitializeList()
        {
            return new List<CustomObject>
            {
                new CustomObject(),
                new CustomObject(),
                new CustomObject(),
                new CustomObject(),
                new CustomObject(),
                new CustomObject(),
                new CustomObject(),
                new CustomObject(),
                new CustomObject(),
                new CustomObject()
            };
        }
        [Benchmark]
        public List<CustomObject> InitializeListUsingEnumerableRange()
        {
            return Enumerable.Range(0, 10)
                .Select(i => new CustomObject())
                .ToList();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<ListInitiator>();
        }
    }
