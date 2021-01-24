    using (var db = new MyContextDB())
    {
        var book = db.Books.SingleOrDefault(b => b.BookName == textBox1.Text);
        if (book != null)
        {
            try
            {
                book.IsAvailableOnline = radioButton1.Checked;
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
