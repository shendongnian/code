    [HttpGet]
    public JsonResult Index()
    {
        var agentList = _databaseContext.Agents
                                        .Include(agent=> agent.Configuration)
                                        .ToList();;
        return new JsonResult(agentList);
    }
