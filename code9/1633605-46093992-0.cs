        var updates = new List<WriteModel<User>>();
        foreach (User appUser in users)
        {
            FilterDefinition<User> filter = Builders<User>.Filter.Eq(x => x.Username, appUser.Username) & ...
            var bsonDoc = appUser.ToBsonDocument();
            UpdateDefinition<User> updateDefinition = new UpdateDefinitionBuilder<User>().Unset("______"); // HACK: I found no other way to create an empty update definition
            foreach (var element in bsonDoc.Elements)
            {
                if (element.Name == "_id" || element.Value == BsonNull.Value)
                    continue;
                updateDefinition = updateDefinition.SetOnInsert(element.Name, element.Value);
            }
            UpdateOneModel<User> update = new UpdateOneModel<User>(filter, updateDefinition) { IsUpsert = true };
            updates.Add(update);
        }
        MongoConnectionHelper.Database.GetCollection<User>("Users").BulkWrite(updates);
