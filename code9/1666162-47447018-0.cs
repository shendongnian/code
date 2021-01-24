       protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            ConfigureCaneRidge();
            ConfigureTestBuilding();
            ConfigureBuilding();
            
        }
        private void ConfigureCaneRidge()
        {
            Container.RegisterType<IBuilding, CaneRidgeBuilding>();
            Container.RegisterType<IDepartmentInfo, SCSC>();
            Container.RegisterType<IDepartmentInfo, ARS>();
        }
        private void ConfigureTestBuilding()
        {
            Container.RegisterType<IBuilding, TestBuilding>();
            Container.RegisterType<IDepartmentInfo, HIIM>();
        }
        private void ConfigureBuilding()
        {
            ObservableCollection<IDepartmentInfo> caneRidgeDefaultDepartments = new ObservableCollection<IDepartmentInfo>
            {
                Container.Resolve<SCSC>(),
                Container.Resolve<ARS>()
            };
            ObservableCollection<IDepartmentInfo> testBuildingDepartmentInfos = new ObservableCollection<IDepartmentInfo>
            {
                Container.Resolve<HIIM>()
            };
            ObservableCollection<IBuilding> Buildings = new ObservableCollection<IBuilding>
            {
                Container.Resolve<CaneRidgeBuilding>(new ParameterOverride("departments",caneRidgeDefaultDepartments)),
                Container.Resolve<TestBuilding>(new ParameterOverride("departments",testBuildingDepartmentInfos))
            };
            Container.RegisterInstance(typeof(ObservableCollection<IBuilding>), Buildings, new ExternallyControlledLifetimeManager());
        }
