    [ResponseType(typeof(decimal))]
    [Route("api/BooksWithAuthers/{id}/Price")]
    public IHttpActionResult GetBooksPriceById(int? id)
    {
       decimal bookprice = db.findBookPrice(id);
       return Ok(bookprice);
    }
    [ResponseType(typeof(decimal))]
    [Route("api/BooksWithAuthers/{id}/{name}/Price")]
    public IHttpActionResult GetBooksPriceById(int? id,string name = null)
    {
        decimal bookprice = db.findBookPrice(id,name);
    
        return Ok(bookprice);
    }
