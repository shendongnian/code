    using (var context = new YourDbContext())
    {
        var result = context.Chapter.SingleOrDefault(b => b.ISBN == book.ISBN);
        if (result != null)
        {
            result.chapterName = @"/root/my/audios";
            context.SaveChanges();
        }
    }
