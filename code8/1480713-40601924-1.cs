            services.AddMvc()
                .AddJsonOptions(options =>
                {
                    // handle loops correctly
                    options.SerializerSettings.ReferenceLoopHandling =
                                    Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                    // use standard name conversion of properties
                    options.SerializerSettings.ContractResolver =
                                    new CamelCasePropertyNamesContractResolver();
                    // include $id property in the output
                    options.SerializerSettings.PreserveReferencesHandling =
                                    PreserveReferencesHandling.Objects;
                }).AddMvcOptions(options =>
                {
                    options.ModelBinderProviders.Insert(0, new DataTableRequestProvider());
                });
