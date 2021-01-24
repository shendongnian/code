    public void Delete(BOOK bookObj)
    {
        using (var db = new LibraryDBEntitiesAws())
        {
            BOOK bookToRemove = db.BOOKs.Find(bookObj.ISBN);
            foreach (AUTHOR a in bookObj.AUTHORs) 
            {
                if (!db.AUTHORS.Any(a => a.BOOKS.Contains(bookObj)))
                    bookToRemove.AUTHORs.Remove(a);
            }
            bookToRemove.CLASSIFICATION = null;
            db.BOOKs.Remove(bookToRemove);
            db.SaveChanges();
        }
    }
