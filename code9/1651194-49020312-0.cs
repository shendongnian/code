             GlobalConfiguration.Configuration 
                .EnableSwagger(c =>
                    {
                        //....
                        c.UseFullTypeNameInSchemaIds();  // <-- add this
                        //....
                    })
                .EnableSwaggerUi(c =>
                    {
                    });
