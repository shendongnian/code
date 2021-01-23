            private static IEdmModel GetEdmModel()
            {
                ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
                var products = builder.EntitySet<Product>("Products");
                products.EntityType.Count().Filter().OrderBy().Expand().Select();
                return builder.GetEdmModel();
            }
