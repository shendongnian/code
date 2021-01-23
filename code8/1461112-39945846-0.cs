    User user = DBContext.Users
                         .Include(b => b.Books) 
                         .FirstOrDefault(p => p.UserID == userID); 
    
                foreach (string bookId in bookIds)
                {
                    Book book2Remove = user.Books.FirstOrDefault(bk => bk.Id == bookId);  
                    user.Books.Remove(book2Remove);
                } 
    
                DBContext.SaveChanges(); 
