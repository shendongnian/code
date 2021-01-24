    public IHttpActionResult Get(int id, string id1) {
        using (var Entities = new tfmisEntities()) {
            var restaurants = Entities.VI_TimeTotalMontly
                                  .Where(e => e.F0 == id && e.F2 == id1)
                                  .ToList();
    
            var result = new {
                restaurants = restaurants;
            };
            return Ok(result);
        }
    }
