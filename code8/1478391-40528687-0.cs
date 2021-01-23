    [HttpGet]
    [Route("Cats")]
    public IHttpActionResult GetCats(int? catId = null, string name = null) {
    
        if(catId.HasValue) return GetByCatId(catId.Value);
    
        if(!string.IsNullOrEmpty(name)) return GetByName(name);
  
        return GetAllCats();
    }
    private IHttpActionResult GetAllCats() { ... }
    private IHttpActionResult GetByCatId(int catId) { ... }    
    
    private IHttpActionResult GetByName(string name) { ... }
