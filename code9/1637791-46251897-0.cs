            app.MapWhen(
                context => ... // <-- Check Regex Pattern against Context
                branch => branch.UseStatusCodePagesWithReExecute("~/Error")
                .UseMvc(routes =>
                {
                    routes.MapRoute(
                        name: "default",
                        template: "{controller=SecondController}/{action=Index}/{id?}")
                })
                .UseStaticFiles());
