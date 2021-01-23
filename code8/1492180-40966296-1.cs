    [HttpGet("{bool}")]
    public IActionResult GetRoleNames(bool? isActive)
    {
        try
        {
            return Ok(_service.GetRoleNames(isActive));
        }
        catch (Exception ex)
        {
            Log.Error("Failed to get list of role names from the API", ex.Message);
            return BadRequest(ex);
        }
    }
