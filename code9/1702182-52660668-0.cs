       public static IEdmModel GetEdmModel(IServiceProvider serviceProvider)
        {
            ODataConventionModelBuilder builder = new DataConventionModelBuilder(serviceProvider);
            builder.EntitySet<YourModel>("YourModels")
            .EntityType
           
            return builder.GetEdmModel();
        }
    }
