    var badIdea = newServer[] { entity, serverB };
    var alsoBad = new ServerType[] { ServerType.Web, ServerType.Database };
    if (badIdea.All(s => alsoBad.Contains(s.ServerType)))
    {
    }
