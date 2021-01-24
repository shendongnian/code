    using (var context = new YourDbContext())
    {
        var result = context.Chapter.Where(b => b.ISBN == book.ISBN).ToList();
        if (result.Any())
        {
            foreach(var chapter in result)
            {
               chapter.chapterName = @"/root/my/audios";
            }
            
            context.SaveChanges();
        }
    }
