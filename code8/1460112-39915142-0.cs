    var query = _graphClient.Cypher
        .Match("(movie:Movie)-[link]->(person)")
        .Where((Movie movie) => movie.Title == "The Princess Bride")
        .Return(person => new {
            Node = person.As<Node<string>>(),
            Labels = person.Labels()
         });
    var actors = new List<Actor>();
    var directors = new List<Director>();
    foreach(var person in query.Results)
    {
        if(person.Labels.Contains("Actor")
            actors.Add(JsonConvert.DeserializeObject<Actor>(person.Node.Data));
        if(person.Labels.Contains("Director")
            directors.Add(JsonConvert.DeserializeObject<Director>(person.Node.Data));
        /* ETC */
    }
