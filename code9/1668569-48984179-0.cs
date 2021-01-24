    await JobsCollection.Indexes.CreateOneAsync(
                    Builders<JobModel>.IndexKeys
                        .Ascending(i => i.Name), 
                    new CreateIndexOptions<JobModel>
                    {
                        Unique = true,
                        PartialFilterExpression = Builders<JobModel>.Filter.Eq(i => i.IsArchived, true)
                    });
