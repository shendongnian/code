            var client = new MongoClient();
            var db = client.GetDatabase("dataBase");
            var msgs = db.GetCollection<Entity>("collection");
            //if you need a filter too
            var filter = Builders<Entity>.Filter.Gt("date",new DateTime(2001,1,1));
            var sort = Builders<Entity>.Sort.Descending("date");
            List<Entity> result = await msgs.Find(filter).Sort(sort).Limit(50).ToListAsync();
