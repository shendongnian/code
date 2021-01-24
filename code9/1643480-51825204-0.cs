    [HttpGet]
    [ExactQueryParam("active")]
    public IEnumerable<UserSelectAllSprocResult.DataRow> GetAll(
      [FromQuery] bool active)
    {
      return ...
    }
    [HttpGet]
    [ExactQueryParam("active", "companyId")]
    public IEnumerable<UserSelectAllByCompanySprocResult.DataRow> GetByCompanyId(
      [FromQuery] bool active, [FromQuery] int companyId)
    {
      return ...;
    }
