    var newArticle = new Articles();
    
    newArticle.Artname = addarticle.Articlename;
    
    // Create the entity and attach it.
    var artDataBase = new ArticleDataBase
    {
        Id = addarticle.ArticlegroupId
    };
    _context.ArticleDatabase.Attach(artDataBase);
    
    newArticle.Artdatabase = artDataBase;
    newArticle.Articleaadddate = DateTime.Now;
    newArticle.Articlelastedit = DateTime.Now;
    newArticle.Artstatus = 3;
    
    _context.Articles.Add(newArticle);
    _context.SaveChanges();
