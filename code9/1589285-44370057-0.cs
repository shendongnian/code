    public IHttpActionResult Post([FromBody]product pro) {    
        try {
            using (var entities = new project_smartEntities()) {
                entities.products.Add(pro);
                entities.SaveChanges();
                return CreatedAtRoute(
                    routeName: "DefaultApi", 
                    routeValues: new { id = pro.product_id, controller = "products" }, //assuming route template "api/{controller}/{id}" other properties
                    content: pro);                
            }
        } catch (Exception ex) {
            return BadRequest();
        }    
    }
