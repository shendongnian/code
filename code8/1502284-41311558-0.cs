    private static Dictionary<User, NextFiledStrig> s_nextFiledByUser = new Dictionary<User, NextFiledStrig>();
    private static GetNextFiledForUser(User user) {
        NextFiledStrig value;
        bool isCached = s_nextFiledByUser.TryGetValue(user, out value);
        if (!isCached) {
            value = new NextFiledStrig(); //Replace this by the code that will get the value
            nextFiledByUser.Add(user, value);
        }
        return value;
    }
