    var types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(ass => ass.ExportedTypes)
                              .Where(type => type.IsInstanceOfType(typeof(ICollector)));
                foreach (var item in types)
                {
                    services.AddTransient(typeof(ICollector), item);
                }
