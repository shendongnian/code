    [Route("")]
    public async Task<IHttpActionResult> Put(MyModel myModel)
    {
        //Parsing to Business Entity   
        var item = TheFactory.Parse(myModel);
        bool result = await _myBL.UpdateLab(item);
        if (!result)
        {
            return BadRequest("Error in Save");
        }        
        return GetById(item.Id);
    }
