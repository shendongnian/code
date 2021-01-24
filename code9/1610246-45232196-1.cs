        public IEnumerable<Tuple<Type, Props>> CreateCommandHandlerProps()
        {
            var handlerTypes =
                _container.Model.AllInstances.Where(
                        i =>
                            i.PluginType.IsGenericType && i.PluginType.GetGenericTypeDefinition() ==
                            typeof(IHandleCommand<>))
                    .Select(m => m.PluginType);
            foreach (var handler in handlerTypes)
            {
                yield return new Tuple<Type, Props>(handler.GenericTypeArguments.First(), _resolver.Create(handler));
            }
        }
