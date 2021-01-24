    [HttpDelete]
    [Route("DeleteUser/{id:int}")] //Matches DELETE {root}/DeleteUser/5
    public IHttpActionResult Delete(int id) {
        //TODO: check if {id} exists and if not, then return NotFound()
        _UserRepository.Delete(id);
        return Ok();
    }
