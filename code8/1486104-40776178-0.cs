    [HttpGet]
    [Produces(typeof(Employee))]
    [SwaggerResponse(System.Net.HttpStatusCode.OK, Type = typeof(Employee))]
    public async Task<IActionResult> LoadEmployee(string id) {
        var employee = await repository.GetById(id);
        if(employee == null) {
            return NotFound();
        }
        return Ok(employee);
    }
