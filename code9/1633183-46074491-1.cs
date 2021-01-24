    public async Task<IActionResult> GetFileLog(Guid jobId,
        [FromQuery] Guid employeeId,
        [SkipAndTopFromQuery] int? skip,
        [SkipAndTopFromQuery] int? top,
        [FromHeader(Name = "X-Correlation-ID")] string correlationId)
    {
        var employeeIdToValidate = ModelState["employeeId"];
        var jobIdToValidate = ModelState["jobId"];
        if (employeeIdToValidate?.Errors?.Any() ?? true)
            throw new InvalidFileIdException();
        if (jobIdToValidate?.Errors?.Any() ?? true)
            throw new InvalidApplicationIdException();
        if (!ModelState.IsValid)
            return StatusCode((int)HttpStatusCode.BadRequest);
        ....
    }
