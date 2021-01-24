    var corsService = httpContext.RequestServices.GetService<ICorsService>();
    var corsPolicyProvider = httpContext.RequestServices.GetService<ICorsPolicyProvider>();
    var corsPolicy = await corsPolicyProvider.GetPolicyAsync(httpContext, null);
    corsService.ApplyResult(
        corsService.EvaluatePolicy(httpContext, corsPolicy),
        httpContext.Response);
