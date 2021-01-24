    [HttpPost]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Route("api/user/save")]
    public void Save([FromBody]UserInfo userinfo)
    {
        using (var context = new CarWarsEntities())
        {
            var a = "";
        }
    }
