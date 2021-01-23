    News news = db.News.SingleOrDefault(n => n.NewsId == Id);
    Comment comment = new Comment { Body = "This is my comment" };
    NewsComment newsComment = new NewsComment { News = news, Comment = comment };
    news.NewsComments.Add(newsComment);
    db.SaveChanges();
