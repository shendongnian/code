    var statementText = "MATCH (p:Person) RETURN p";
    
    var users = new List<User>();
    using (var session = _driver.Session())
    {
        session.ReadTransaction(tx =>
        {
            var result = tx.Run(statementText);
            foreach(var record in result)
            {
                var nodeProps = JsonConvert.SerializeObject(record[0].As<INode>().Properties);
                users.Add(JsonConvert.DeserializeObject<User>(nodeProps));
            }
        });
    }
