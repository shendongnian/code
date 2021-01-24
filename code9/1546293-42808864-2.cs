    public IActionResult CreatedResponse(object value)
    {
        return new ObjectResult
        {
            Value = value,
            StatusCode = Microsoft.AspNetCore.Http.StatusCodes.Status201Created // 201
        };
    }
