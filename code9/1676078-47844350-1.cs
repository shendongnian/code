        [Route("api/events/getevents/{events}/{producerId}")]
        [HttpPost]
        public async Task<IHttpActionResult> GetEvents(string events, string producerId, [FromBody] MyModel model)
        {
            // your code
        }
    
    Last "model" parameter will be populated with values you send from client.
    **[HttpPost]** attribute indicates that this action will be available only with POST requests.
    **[FromBody]** attribute indicates that Web API should take model from request's body.
