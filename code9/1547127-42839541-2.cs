    public void Delete(BOOK bookObj)
    {
        using (var db = new LibraryDBEntitiesAws())
        {
            BOOK bookToRemove = db.BOOKs.Find(bookObj.ISBN);
            foreach (AUTHOR a in bookObj.AUTHORs) 
            {
                // Get the count of other books by the author
                var authBooks = db.BOOKS.Where(b => b.AUTHORs.Contains(a) 
                    && b.ISBN != bookObj.ISBN).Count();
                // Check that the author does not have any books other 
                // than the one to be deleted
                if (authbooks != 0)
                    bookToRemove.AUTHORs.Remove(a);
            }
            bookToRemove.CLASSIFICATION = null;
            db.BOOKs.Remove(bookToRemove);
            db.SaveChanges();
        }
    }
