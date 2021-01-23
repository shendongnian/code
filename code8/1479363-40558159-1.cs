    using System;
    using System.Collections.Generic;
    using System.Linq;
<!----!>
    public static class PagingExtensions
    {
        public static PagedList<T> ToPagedList<T>(this IEnumerable<T> source, 
            int pageNumber, int pageSize) where T : class
        { return source.AsQueryable().ToPagedList(pageNumber, pageSize); }
        public static PagedList<T> ToPagedList<T>(this IQueryable<T> source, 
            int pageNumber, int pageSize) where T : class
        { return CreatePagesList<T>(source, pageNumber, pageSize); }
        private static PagedList<T> CreatePagesList<T>(IQueryable<T> source, 
            int pageNumber, int pageSize) where T : class
        {
            var items = new List<T>();
            var pageIndex = pageNumber - 1;
            if (source == null) source = new List<T>().AsQueryable();
            var totalItemsCount = source.Count();
            if (pageNumber < 1)
                throw new ArgumentOutOfRangeException("pageNumber cannot be less than 1.");
            if (pageSize < 1)
                throw new ArgumentOutOfRangeException("pageSize cannot be less than 1.");
            var pageCount = 0;
            if (totalItemsCount > 0)
                pageCount = (int)Math.Ceiling(totalItemsCount / (double)pageSize);
            if (pageIndex >= pageCount)
                pageIndex = Math.Max(pageCount - 1, 0);
            if (pageIndex < pageCount && totalItemsCount > 0)
                items.AddRange(source.Skip((pageIndex) * pageSize).Take(pageSize).ToList());
            var pagedList=  new PagedList<T>()
            {
                PageNumber = pageNumber, PageSize = pageSize,
                PageCount = pageCount, TotalItemsCount = totalItemsCount
            };
            pagedList.AddRange(items);
            return pagedList;
        }
    }
