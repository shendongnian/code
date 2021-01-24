    public IEnumerable<MultiCollection> GetAll(int userId)
    {
        string query = @"select MC.*, C.* from MultiCollections  MC
                        left join MultiCollectionCollections MCC on MC.Id = MCC.MultiCollectionId
                        left join  Collections C on MCC.CollectionId = C.Id
                        where UserId=" + userId;
        using (DbConnection connection = ConnectionFactory())
        {
            connection.Open();
            return connection.Query<MultiCollection, Collection, MultiCollection>(query,
                (a, s) =>
                {
                    a.Collections = new List<Collection>();
                    a.Collections.Add(s);
                    return a;
                }, splitOn: "CollectionId"););
        }
    }
