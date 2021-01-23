    [AcceptVerbs(HttpVerbs.Get)]
    public async Task<ActionResult> MethodName()
    {
        return json(model, JSonRequestBehavior.AllowGet);
    }
