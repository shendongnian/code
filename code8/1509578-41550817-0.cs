        public async Task<Round> GetRound(int id)
        {
            IMongoCollection<Round> collection = m_db.GetCollection<Round>("Rounds");
            FilterDefinition<Round> filter = Builders<Round>.Filter.Eq("Round", id);
            return await collection.Find(filter).SingleOrDefaultAsync();
        }
