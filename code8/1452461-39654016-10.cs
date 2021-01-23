    public class Convertor
    { 
        private readonly ICache _cache;
        public Convertor(ICache cache)
        {
            _cache = cache;
        }
        public string GetGradeName(int gradeId)
        {
            var gradeList = _cache.Get<List<Grade>>(CacheKeys.Grades);
            return gradeList.Where(x => x.Id == gradeId).Select(x => x.Name).FirstOrDefault();
        }
    }
