    var newArticle = new Articles();
    
    newArticle.Artname = addarticle.Articlename;
    // Note that I'm using ArtdatabaseId and not Artdatabase.
    newArticle.ArtdatabaseId = addarticle.ArticlegroupId
    
    newArticle.Articleaadddate = DateTime.Now;
    newArticle.Articlelastedit = DateTime.Now;
    newArticle.Artstatus = 3;
    
    _context.Articles.Add(newArticle);
    _context.SaveChanges();
