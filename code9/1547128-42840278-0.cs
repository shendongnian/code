    public void Delete(BOOK bookObj)
    {
        using (var db = new LibraryDBEntitiesAws())
        {
            BOOK bookToRemove = db.BOOKs
                .Include("AUTHORs")
                .FirstOrDefault(b => b.ISBN == bookObj.ISBN);
    
            var aids = bookToRemove.AUTHORs.Select(a => a.Aid).ToList();
            foreach (var aid in aids)
            {
                var authorToRemove = bookToRemove.AUTHORs.First(a => a.Aid == aid);
                bookToRemove.AUTHORs.Remove(authorToRemove);
            }
    
            db.BOOKs.Remove(bookToRemove);
            db.SaveChanges();
        }
    }
