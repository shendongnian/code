    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices.ComTypes;
    
    public class ResultSet
    {
        public List<T> GetResult<T>(string search, string sortOrder, int start, int length, List<T> dtResult, List<string> columnFilters) where T : class
        {
            return FilterResult(search, dtResult, columnFilters).OrderBy(sortOrder).Skip(start).Take(length).ToList();
        }
        public int Count<T>(string search, List<T> dtResult, List<string> columnFilters) where T : class
        {
                return FilterResult(search, dtResult, columnFilters).Count();
        }
        private IQueryable<T> FilterResult<T>(string search, List<T> dtResult, List<string> columnFilters) where T : class
        {
            IQueryable<T> results = dtResult.AsQueryable();
            results = results.Where(p => (search == null || (p.Name != null && p.Name.ToLower().Contains(search.ToLower()) || p.PublicDisplayNo != null && p.PublicDisplayNo.ToLower().Contains(search.ToLower()))));
            return results;
        }
    }
