    public class MyDependentClass {
        private readonly ICache _cache;
        public MyDependentClass(ICache cache)
        {
            _cache = cache;
        }
        public int CountGradesInCache()
        {
            // Behavior depends on what's in the _cache object
            return _cache.Get<List<Grade>>("GradeList").Count;
        }
    }
