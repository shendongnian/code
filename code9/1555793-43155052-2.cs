    services.AddMvc(options =>
    {
        options.Filters.Add(new Microsoft.AspNetCore.Mvc.ProducesResponseTypeAttribute(typeof(ApiError), 400));
        options.Filters.Add(new Microsoft.AspNetCore.Mvc.ProducesResponseTypeAttribute(typeof(ApiError), 401));
        options.Filters.Add(new Microsoft.AspNetCore.Mvc.ProducesResponseTypeAttribute(typeof(ApiError), 409));
    });
