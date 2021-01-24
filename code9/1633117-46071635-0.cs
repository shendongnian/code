    GlobalConfiguration.Configuration 
        .EnableSwagger(c =>
        {
            // your configs...
            c.SchemaId(x => x.FullName);
            
            // other configs...
        })
        .EnableSwaggerUi(c =>
            // ....
        });
