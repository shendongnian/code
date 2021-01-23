    app.UseExceptionHandler(
        options =>
        {
            //options.UseDeveloperExceptionPage();
            options.Run(
                async context =>
                {
                    var ex = context.Features.Get<IExceptionHandlerFeature>();
                    if (ex != null)
                    {
                        var err = $"<h1>Error: {ex.Error.Message}</h1>{ex.Error.Source}<hr />{context.Request.Path}<br />";
                        err += $"QueryString: {context.Request.QueryString}<hr />";
    
                        err += $"Stack Trace<hr />{ex.Error.StackTrace.Replace(Environment.NewLine, "<br />")}";
                        if (ex.Error.InnerException != null)
                            err +=
                                $"Inner Exception<hr />{ex.Error.InnerException?.Message.Replace(Environment.NewLine, "<br />")}";
                        // This bit here to check for a form collection!
                        if (context.Request.HasFormContentType && context.Request.Form.Any())
                        {
                            err += "<table border=\"1\"><tr><td colspan=\"2\">Form collection:</td></tr>";
                            foreach (var form in context.Request.Form)
                            {
                                err += $"<tr><td>{form.Key}</td><td>{form.Value}</td></tr>";
                            }
                            err += "</table>";
                        }
    
                        await msg.SendEmailAsync(appSettings.Value.ErrorDeliveryEmailAddress, "CMP v2 error",
                            err);
                        context.Response.Redirect("/Home/Error?r=" +
                                                    System.Net.WebUtility.UrlEncode(context.Request.Path + "?" +
                                                                                    context.Request.QueryString));
                    }
                });
            //options.UseExceptionHandler("/Home/Error");
            options.UseStatusCodePagesWithReExecute("/Home/Error/{0}");
        }
    );
