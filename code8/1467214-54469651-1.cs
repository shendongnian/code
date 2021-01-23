public void Configure(IApplicationBuilder app, IHostingEnvironment 
{
   app.UseMvcWithDefaultRoute();
}
Can be used to change:
public void Configure(IApplicationBuilder app, IHostingEnvironment 
{
   app.UseMvc(routes =>
   {
      routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
   });
}
More info in [Microsoft documentation][1]
  [1]: https://docs.microsoft.com/en/aspnet/core/mvc/controllers/routing?view=aspnetcore-2.2
