            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddScoped<IService>(provider =>
            {
                var actionContextAccessor = provider.GetService<IActionContextAccessor>();
                var descriptor = actionContextAccessor.ActionContext.ActionDescriptor as ControllerActionDescriptor;
                var areaName = descriptor.ControllerTypeInfo.GetCustomAttribute<AreaAttribute>().RouteValue;
                if(areaName == "FooArea")
                {
                    return new FooService();
                }
                else
                {
                    return new BarService();
                }
            });
