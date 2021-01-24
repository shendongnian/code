    .Select(p => new InsightList
    {
        Heading = p.Heading,
        Topics = p.InsightTopicsJoins.Select(itj => itj.InsightTopic.Name).ToList()
    }
