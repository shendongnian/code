    public Task DeleteUser(string id)
    {
        SingleResult<User> result = Lookup(id);
        var user=result.Queryable.SingleOrDefault();
        if(user!=null)
        {
          //I need GroupNm from the object to send a group notification
          PostNotification(user.GroupNm, ...);
          return DeleteAsync(id);
        }
        return Task.FromException($"the specific user with userid:{id} is not found.");
    }
