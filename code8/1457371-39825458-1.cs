          using MvcPaging;
    
          public ActionResult Index(int? page) {
                int currentPageIndex = page.HasValue ? page.Value : 1;
    
                var results = db.Reviews.Include(m => m.User);
                results = results.OrderBy(a => a.Id);
    
                var totalCount = results.Count();
                var pagedResults = results.ToPagedList(currentPageIndex, defaultPageSize, totalCount);
            
            return View(pagedResults ;           
           }
