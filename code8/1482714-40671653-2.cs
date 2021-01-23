    static IEnumerable<string> GetUsersByGenderOrderByMutualFriends(string user, string gender)
    {
        var db = mux.GetDatabase();
        var tempKey = "temp";
        db.SortedSetCombineAndStore(SetOperation.Intersect, tempKey, $"gender:{gender}", $"mutual:{user}", Aggregate.Sum);
        var result = db.SortedSetRangeByRank(tempKey, 0, -1, Order.Descending).Select(x => x.ToString());
        db.KeyDelete(tempKey);
        return result;
    }
