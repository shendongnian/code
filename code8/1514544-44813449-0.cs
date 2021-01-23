    [HttpPost, Route("create")]
    public ActionResult CreateMyObject([FromBody]Creature newCreature)
    {
        string id = // some new object id
        var newPath = new Uri(HttpContext.Request.Path, id);
        return this.Created(newPath);
    }
