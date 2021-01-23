    [ResponseType(typeof(decimal))]
    [Route("api/BooksWithAuthers/{id}/{name}/Price")]
    public IHttpActionResult GetBooksPriceById(int id,string name)
    {
        decimal bookprice = db.findBookPrice(id,name);
    
        return Ok(bookprice);
    }
