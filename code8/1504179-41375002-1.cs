    public JsonResult GetBooks(string context)
    {
       string rating = context.Split('?')[0];
       string[] authors = context.context.Split('?')[1].Split(',');
       var books = db.Books.Where(s => authors.Contains(s.AuthorName) && s.Rating == rating);
       return Json(books, JsonRequestBehavior.AllowGet); 
    }
