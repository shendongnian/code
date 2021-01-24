      services.AddMvc().ConfigureApiBehaviorOptions(options =>
      {
        options.InvalidModelStateResponseFactory = c =>
        {
          var errors = string.Join('\n', c.ModelState.Values.Where(v => v.Errors.Count > 0)
            .SelectMany(v => v.Errors)
            .Select(v => v.ErrorMessage));
          return new BadRequestObjectResult(new
          {
            ErrorCode = "Your validation error code",
            Message = errors
          });
        };
      });
