    services.AddMvc(options =>
    {
        options.Filters.Add(new Microsoft.AspNetCore.Mvc.ProducesResponseTypeAttribute(typeof(void), 400));
        options.Filters.Add(new Microsoft.AspNetCore.Mvc.ProducesResponseTypeAttribute(typeof(void), 401));
        options.Filters.Add(new Microsoft.AspNetCore.Mvc.ProducesResponseTypeAttribute(typeof(void), 409));
    });
