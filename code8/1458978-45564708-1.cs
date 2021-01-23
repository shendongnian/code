    services.AddOData();
    // ...
    app.UseMvc(routes =>
    {
      ODataModelBuilder modelBuilder = new ODataConventionModelBuilder();
      modelBuilder.EntitySet<Product>("Products");
      IEdmModel model = modelBuilder.GetEdmModel();
      routes.MapODataRoute(
        prefix: "odata",
          model: model
      );
