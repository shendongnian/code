            public void CollectAndRegisterViews()
        {
            Assembly assembly = Assembly.GetCallingAssembly();
            var viewNamespace = $"{assembly.GetName().Name}.{_defaultAssemblyFolder}";
            var types = from type in assembly.GetTypes().Where(x=>x.Namespace==viewNamespace)
                        where Attribute.IsDefined(type, typeof(RegionRegistrationAttribute))
                        select type;
            foreach (var type in types)
            {
                Debug.WriteLine($"\t>>Registering View by type{type.FullName}");
                var attribute = type.GetCustomAttributes<RegionRegistrationAttribute>().FirstOrDefault();
                RegisterViewInUnityContainerAndRegionManager(type, attribute);
            }
        }
