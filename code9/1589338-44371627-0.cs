     private static IEdmModel GetEDMModel()
     {
           ODataModelBuilder builder = new ODataConventionModelBuilder();
           var entitySet = builder.EntitySet<TestEntity>("TestEntities");
           entitySet.EntityType.HasKey(entity => entity.EntityID)
           return builder.GetEdmModel();
     }
