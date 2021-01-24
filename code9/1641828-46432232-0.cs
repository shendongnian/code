    public FileStreamResult ReadArticle(int id)
    {
        Article article = _context.Articles
            .Where(a => a.ID == id)
            .AsNoTracking()
            .SingleOrDefault();
        var pdfPath = article.OriginalArticlePathname;
        FileStream fs = new FileStream(pdfPath, FileMode.Open, FileAccess.Read);
        return File(fs, "application/pdf");
    }
