    [Route("values/{idList}")]
    public IHttpActionResult Get([FromUri] int[] idList)
    {
        var data = new string[] { "value1", "value2" };
        return Json(data);
    }
    
