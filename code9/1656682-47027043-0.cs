    class Extension
    {
        public static User Get(this ConcurrentDictionary<int, User> conDict, int userID)
        {
            User user = null;
            if (!conDict.TryGetValue(userID, out user))
            {
                user = GetSlowDbResultAsync(userId, cancellationToken)
               conDict.TryAdd(userID, user);
            }
            return user;
        }
    }
