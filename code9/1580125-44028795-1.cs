    public IHttpActionResult Get() {
    	var response = db.YourTable.Select(x=>new{
           x.PeopleId,
           x.PeopleName,
           x.ProductId,
           Product= new {
             x.ProductId,
             x.ProductName  
           }
        }).toList();
        return Ok(response);
    }
