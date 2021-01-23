    public void CreateRelationship(IGraphClient graphClient, string relationshipName)
    {
        graphClient.Cypher
            .Match("(user1:User)", "(user2:User)")
            .Where((User user1) => user1.Id == 123)
            .AndWhere((User user2) => user2.Id == 456)
            .CreateUnique($"(user1)-[:{relationshipName}]->(user2)") //<-- here
            .ExecuteWithoutResults();
    }
