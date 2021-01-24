        protected override void AttachToComponentRegistration(
            IComponentRegistry componentRegistry, IComponentRegistration registration)
        {
            base.AttachToComponentRegistration(componentRegistry, registration);
            if (registration.Activator.LimitType.IsSubclassOf(typeof(BaseController)))
            {
                String controllerName = registration.Activator.LimitType.Name;
                controllerName = controllerName.Substring(0, controllerName.Length - 10);
                if (Enum.TryParse<CacheType>(controllerName, out CacheType cacheType))
                {
                    registration.Preparing += (sender, e) =>
                    {
                        e.Parameters = new Parameter[]
                                       {
                                          ResolvedParameter.ForKeyed<ICacheProvider>(cacheType)
                                       }
                                       .Concat(e.Parameters);
                    };
                }
                else
                {
                    // throw, use default cache, do nothing, etc.
                    throw new Exception($"No cache found for controller {controllerName}");
                }
            }
        }
    }
