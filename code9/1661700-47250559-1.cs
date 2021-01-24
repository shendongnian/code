    public HttpResponseMessage Get(string id)
    {
        var events = db.userattends.Where(x => x.userID == id).Select(s => s.eventID).ToList();
        
        return Request.CreateResponse(HttpStatusCode.OK, events);
    }
