    var lang = new List<string> { "FR", "EN" };
    
                var orderedItems = from post in db.Posts
                                   orderby (lang[0] == post.Lang) ? 0 :((lang[1] == post.Lang) ? 1 : 2)
                                   select post;
    
                var param = Expression.Parameter(typeof(Post));
    
                var order = lang.Select((s, i) => new { s, i })
                    .Aggregate((Expression)Expression.Constant(lang.Count), (agg, i) =>
                                                    Expression.Condition(
                                                        Expression.Equal(Expression.Property(param,nameof(Post.Lang)), Expression.Constant(i.s)),
                                                        Expression.Constant(i.i),
                                                        agg));
                var exp = Expression.Lambda<Func<Post, int>>(order, param);
                var data = db.Posts.OrderBy(exp).ToList();
