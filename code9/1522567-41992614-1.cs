    var escalationMapper = _factory.GetEscalationMapper();
    //we only get one object with a list of triggers but the interface returns a list. Change the interface? 
    var escalation = escalationMapper.Get(trackingGroupCode);
    _factory.Release(escalationMapper);
    response = Request.CreateResponse(contract == null ? HttpStatusCode.NotFound : HttpStatusCode.OK, contract);
