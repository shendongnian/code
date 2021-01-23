    [HttpPost("ByYear")]
    public async Task<IActionResult> GetStudentDetailByYear([FromBody]SearchStudentModel model)
    {
       if (string.IsNullOrWhiteSpace(model.query)
           || string.IsNullOrWhiteSpace(model.AcademicYearID))
           return BadRequest("Required Parameter not provided");
    
          // some codes to handle the query
     }
