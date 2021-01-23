    public ActionResult Details(Guid id)
    {
       var vm = new ListAndCreateVm { BookId= id};
       vm.Comments = GetComments(id);
       return View(vm);
    }
    private List<CommentVm> GetComments(Guid bookId)
    {
       return db.CommentToBooks.Where(c => c.BookId == bookId)
                                      .Select(x=> new CommentVm { Comment = x.Comment})
                                      .ToList();
    }
