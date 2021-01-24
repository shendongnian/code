    try
    {
        await _testTableTbRepository.DeleteAsync(model.Id);
        return Ok(model.Id);
    }
    catch(DbException e)
    {
       return StatusCode(404, "Id: " + model.Id + " does not exist");
    }
    catch (Exception e)
    {
        return StatusCode(500, e);
    }
