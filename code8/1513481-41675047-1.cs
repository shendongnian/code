    [HttpGet]
    public ActionResult AddChapter(long bookId) {
        var book = dbContext.Books.Find(bookId);
        var viewModel = new AddChapterViewModel {
            BookId = bookId,
            BookName = book.Name,
            ChapterName = string.Empty // to be provided by User in AddChapter view
            // ...
        };
        return View("AddChapter", viewModel);
    }
    [HttpPost]
    public ActionResult AddChapter(AddChapterViewModel postData) {
        var book = dbContext.Books.Find(postData.BookId);
        
        var newChapter = new Chapter {
            Name = postData.ChapterName,
            // ...
        };
        book.Chapters.Add(newChapter);
        dbContext.SaveChanges();
        return new HttpStatusCodeResult(HttpStatusCode.OK);
    }
