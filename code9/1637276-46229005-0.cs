    CHANGE_TYPE_TO_TYPE_OF_RETURN-TYPE GetMostActiveTopicByUserID(int id)
     {
      return _databaseContext.Users.Where(q => q.ID == id)
      .Select(user => 
        {
         user.Posts.GroupBy(post => post.Topic.ID)
                    .OrderByDescending(post => post.Count())
                    .FirstOrDefault()
    }).Single();
    }
