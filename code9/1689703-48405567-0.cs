    try
    {
        try
        {
          await _testTableTbRepository.DeleteAsync(model.Id);
        }
        catch(DbException e)
        {
          return StatusCode(404, "Id: " + model.Id + " does not exist");
        }
        return Ok(model.Id);
    }
    catch (Exception e)
    {
        return StatusCode(500, e);
    }
