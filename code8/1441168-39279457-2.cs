        var provider = services.BuildServiceProvider().GetRequiredService<IActionDescriptorCollectionProvider>();
        var ctrlActions = provider.ActionDescriptors.Items
                .Where(x => (x as ControllerActionDescriptor)
                .ControllerTypeInfo.AsType() == typeof(Home222Controller))
                .ToList();
        foreach (var action in ctrlActions)
        {
             var descriptor = action as ControllerActionDescriptor;
             var controllerName = descriptor.ControllerName;
             var actionName = descriptor.ActionName;
             var areaName = descriptor.ControllerTypeInfo
                    .GetCustomAttribute<AreaAttribute>().RouteValue;
        }
