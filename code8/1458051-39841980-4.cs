    var viewModelList = new List<BlogViewModel>();
    _context.Blogs.ForEach(b => 
    {
      viewModelList.Add(new BlogViewModel
       {
         Id = b.BlogId,
         Name = b.BlogName,
         IsNotified = b.IsNotified
       });
    });
    return View(viewModelList);
