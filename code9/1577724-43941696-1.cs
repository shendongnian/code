    [HttpPost]
    public IHttpActionResult ReceiveJSON([FromBody]List<Dictionary<string,string>> in_json)
        {
            // And then one way to iterate over each 'json node' passed
            foreach(var dict in in_json)
            {
             // Do something with dictionary object
            }
            return Ok(in_sjon);
        }
