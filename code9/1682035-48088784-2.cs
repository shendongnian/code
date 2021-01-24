            // introducing temporary storage
            var usersDictionary = new Dictionary<int, User>();
            var sql = @"SELECT 1 Id, 1 UserId, 'EventText1' EventText
                      union SELECT 2 Id, 2 UserId, 'EventText2'  EventText
                      union SELECT 2 Id, 2 UserId, 'Another EventText2' EventText";
            var result = SqlMapper.Query<User, Event, User>(connection, sql, (u, e) =>
            {
                if (!usersDictionary.ContainsKey(u.Id))
                    usersDictionary.Add(u.Id, u);
                var cachedUser = usersDictionary[u.Id];
                if (cachedUser.Events == null)
                    cachedUser.Events = new List<Event>();
                cachedUser.Events.Add(e);
                return cachedUser;
            }, splitOn: "UserId");
            // we are not really interested in `result` here
            // we are more interested in the `usersDictionary`
            var users = usersDictionary.Values.AsList();
            Assert.AreEqual(2, users.Count);
            Assert.AreEqual(1, users[0].Id);
            CollectionAssert.IsNotEmpty(users[0].Events);
            Assert.AreEqual(1, users[0].Events.Count);
            Assert.AreEqual("EventText1", users[0].Events[0].EventText);
            Assert.AreEqual(2, users[1].Events.Count);
 
