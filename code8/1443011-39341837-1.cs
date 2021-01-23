    public ActionResult Index(int id)
    {
            IQueryable<Document> documents = _dbContext.Document.OrderBy(x=>x.Id);
    
            var model = new DocumentListViewModel()
            {             
                Documents = documents
            };
    
            return View(model);
    }
