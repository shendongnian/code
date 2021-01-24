        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            Container.RegisterTypes(AllClasses.FromLoadedAssemblies()
               .Where(type => typeof(IDepartment).IsAssignableFrom(type)), WithMappings.FromAllInterfaces, WithName.TypeName, WithLifetime.None);
            ObservableCollection<IBuilding> Buildings = new ObservableCollection<IBuilding>()
            {
                Container.Resolve<Building1>(new ParameterOverride("departments",GetDepartmentCollection("Building1"))),
                Container.Resolve<Building2>(new ParameterOverride("departments",GetDepartmentCollection("Building2")))
                
            };
            Container.RegisterInstance(typeof(ObservableCollection<IBuilding>), Buildings,
                new ExternallyControlledLifetimeManager());
        }
        private ObservableCollection<IDepartment> GetDepartmentCollection(string buildingName)
        {
            var departments = new List<IDepartment>();
            foreach (var registration in Container.Registrations.Where( s => s.MappedToType.Namespace.Contains(buildingName)))
            {
                departments.Add((IDepartment)Container.Resolve(registration.MappedToType));
            }
            return new ObservableCollection<IDepartment>(departments);
        }
       
