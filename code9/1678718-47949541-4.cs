    public class ConcurrentCalculationProcessor
    {
        private const int MAX_CONCURRENT_TASKS = 4;
        private readonly IEnumerable<int> _codes;
        private readonly List<Task<Dictionary<string, CalculationResult>>> _tasks;
        private readonly Dictionary<string, CalculationResult> _combinationsReal;
        public ConcurrentCalculationProcessor(IEnumerable<int> codes)
        {
            this._codes = codes;
            this._tasks = new List<Task<Dictionary<string, CalculationResult>>>();
            this._combinationsReal = new Dictionary<string, CalculationResult>();
        }
    }
