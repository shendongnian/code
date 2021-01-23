        public async Task<long> GetRoundCount(int id)
        {
            IMongoCollection<Round> collection = m_db.GetCollection<Round>("Rounds");
            FilterDefinition<Round> filter = Builders<Round>.Filter.Eq("Round", id);
            return await Task.Run(() => collection.Find(filter).Count());
        }
