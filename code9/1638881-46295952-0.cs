    var x = MongoCollection.Aggregate()
                        .Group(
                                doc => doc.clientId,
                                group => new
                                {
                                    clientId = group.Key,
                                    Total = group.Sum(y => y.sum)
                                }
                        ).ToList().FirstOrDefault(c => c.clientId == 2).Total;
