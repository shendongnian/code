    namespace DL.SO.Project.Framework.Mvc.Paginations
    {
        public class Pager
        {   
            public int TotalItems { get; private set; }
            public int CurrentPage { get; private set; }
            public int CurrentPageSize { get; private set; }
            public int TotalPages { get; private set; }
            public int StartPage { get; private set; }
            public int EndPage { get; private set; }
    
            public Pager(int totalItems, int currentPage = 1, int currentPageSize = 15)
            {
                currentPageSize = currentPageSize < 15
                    ? 15
                    : currentPageSize;
                // Calculate total, start and end pages
                var totalPages = (int)Math.Ceiling(
                    (decimal)totalItems / (decimal)currentPageSize
                );
    
                currentPage = currentPage < 1
                    ? 1
                    : currentPage;
    
                // Only display +- 2
                var startPage = currentPage - 2;
                var endPage = currentPage + 2;
                if (startPage <= 0)
                {
                    endPage = endPage - startPage + 1;
                    startPage = 1;
                }
                if (endPage > totalPages)
                {
                    endPage = totalPages;
                    if (endPage > 5)
                    {
                        startPage = endPage - 4;
                    }
                }
    
                this.TotalItems = totalItems;
                this.CurrentPage = currentPage;
                this.CurrentPageSize = currentPageSize;
                this.TotalPages = totalPages;
                this.StartPage = startPage;
                this.EndPage = endPage;
            }
        }
    }
