    public static class MongoDatabaseExtentions
    {
        public static async Task<BsonDocument> GetStatsAsync(this IMongoDatabase database)
        {
            return await database.RunCommandAsync<BsonDocument>("{ dbstats: 1 }")
                .ConfigureAwait(false);
        }
    }
