    app.UseStatusCodePages();
     
    // app.UseStatusCodePages(context => context.HttpContext.Response.SendAsync("Handler, status code: " + context.HttpContext.Response.StatusCode, "text/plain"));
    // app.UseStatusCodePages("text/plain", "Response, status code: {0}");
    // app.UseStatusCodePagesWithRedirects("~/errors/{0}"); // PathBase relative
    // app.UseStatusCodePagesWithRedirects("/base/errors/{0}"); // Absolute
    // app.UseStatusCodePages(builder => builder.UseWelcomePage());
    // app.UseStatusCodePagesWithReExecute("/errors/{0}");
