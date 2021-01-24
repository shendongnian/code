            var controllers = Assembly.GetAssembly(typeof(*any type in assembly*))
                .GetTypes()
                .Where(x => x.IsSubclassOf(typeof(Controller)))
                .ToList();
            var result = controllers
                .Select(type => new
                {
                    ControllerType = type,
                    Actions = type.GetMethods()
                    .Where(m => m.ReturnType == typeof(ActionResult) || m.ReturnType.IsSubclassOf(typeof(ActionResult))).ToList()
                })
                .ToList();
